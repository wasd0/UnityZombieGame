using System;

namespace Entities.Components
{
    public abstract class ValueComponent
    {
        private float _value;
        private readonly float _maxValue;

        public event Action<float, float> OnValueChanged;


        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                if (_value <= 0) _value = 0;
                else if (_value >= _maxValue) _value = _maxValue;
                
                OnValueChanged?.Invoke(_value, _maxValue);
            }
        }

        protected ValueComponent(float value, float maxValue)
        {
            _maxValue = maxValue;
            _value = value;
        }
    }
}