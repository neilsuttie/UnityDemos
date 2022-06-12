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

using UnityEngine;

namespace EasyLerp
{
    public class Lerp : MonoBehaviour, ILerp
    {
        [SerializeField] protected float _duration = 0.0f;
        [SerializeField] protected LoopingType _looping;
        [SerializeField] protected bool _playOnAwake = false;
        //[SerializeField] protected int _loopCount;
        [SerializeField] protected Transform _target;
        [SerializeField] protected bool _usingTarget = false;

        [SerializeField] protected SmoothingFunction _smoothingFunction = EasyLerp.SmoothingFunction.linear;
        [SerializeField] protected AnimationCurve _animationCurve = null;

        //PRIVATE FIELDS
        protected bool _isLerping = false;

        protected float GetDuration()
        {
            return _duration;
        }

        protected void SetDuration(float value)
        {
            _duration = value;
        }

        public virtual void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public virtual void StartLerping()
        {
            throw new System.NotImplementedException();
        }

        public virtual void StopLerping()
        {
            throw new System.NotImplementedException();
        }

        protected float SmoothingFunction(float perc)
        {
            switch (_smoothingFunction)
            {
                case EasyLerp.SmoothingFunction.linear:
                    return perc;
                case EasyLerp.SmoothingFunction.easeIn:
                    return 1f - Mathf.Cos(perc * Mathf.PI * 0.5f); ;
                case EasyLerp.SmoothingFunction.easeOut:
                    return Mathf.Sin(perc * Mathf.PI * 0.5f);
                case EasyLerp.SmoothingFunction.exp:
                    return perc * perc;
                case EasyLerp.SmoothingFunction.smoothStep:
                    return perc * perc * (3f - 2f * perc);
                case EasyLerp.SmoothingFunction.smootherStep:
                    return perc * perc * perc * (perc * (6f * perc - 15f) + 10f);
                default:
                    return 0.0f;
            }
        }
    }
}
