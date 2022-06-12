#region License
/*
MIT License

Copyright(c) 2018 Neil Suttie

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

#endregion
using System.Collections;
using UnityEngine;

namespace EasyLerp
{
  
    public class LinearLerp : Lerp, ILerp
    {
        //Depending on the type of action aiming for a target point or a distance to travel
       [SerializeField] Vector3 _distance;
        
        private Vector3 _startPos;
        private Vector3 _endPos;

        private float _timeStartedLerping;

        private void Awake()
        {
            Initialize();

            if (_playOnAwake)
            {
                StartLerping();
            }
        }

        public override void Initialize()
        {

            //Get the time the lerp starts
            _timeStartedLerping = Time.time;

            _startPos = transform.position;

            //Do we have an assigned target position?
            if (_usingTarget && _target != null)
            {
                _endPos = _target.position;
            }
            else
            {
                //Use distance values for target position
                _endPos = _startPos + _distance;
            }
        }

        public override void StartLerping()
        {
            _isLerping = true;
            StartCoroutine(Lerping());
        }

        public override void StopLerping()
        {
            _isLerping = false;
            StopCoroutine(Lerping());
        }


        private IEnumerator Lerping()
        {
            while (_isLerping)
            {
                _timeStartedLerping += Time.deltaTime;

                //if the time since started > timeToTake we are 1.0 or 100% lerped
                if (_timeStartedLerping > base.GetDuration())
                {
                    _timeStartedLerping = GetDuration();

                    if (_looping == LoopingType.yoyo)
                    {
                        _timeStartedLerping = 0.0f;

                        Vector3 temp = new Vector3(_startPos.x, _startPos.y, _startPos.z);
                        _startPos = _endPos;
                        _endPos = temp;
                    }
                    else if (_looping == LoopingType.warp)
                    {
                        _timeStartedLerping = 0.0f;
                        transform.position = _startPos;
                    }
                }

                float perc = _timeStartedLerping / GetDuration();

                if (_smoothingFunction == EasyLerp.SmoothingFunction.UnitySmoothStep)
                {
                    //Unity smoothStep!
                    transform.position = new Vector3(
                        Mathf.SmoothStep(_startPos.x, _endPos.x, perc),
                        Mathf.SmoothStep(_startPos.y, _endPos.y, perc),
                        Mathf.SmoothStep(_startPos.z, _endPos.z, perc));
                }
                else if (_smoothingFunction == EasyLerp.SmoothingFunction.animationCurve)
                {
                    float curvePercent = _animationCurve.Evaluate(perc);
                    transform.position = Vector3.LerpUnclamped(_startPos, _endPos, curvePercent);
                }
                else
                {
                    //Update the percentage for the current smoothing function
                    perc = base.SmoothingFunction(perc);
                    transform.position = Vector3.Lerp(_startPos, _endPos, perc);
                }
                yield return null;
            }
        }
    }
}
