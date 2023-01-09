namespace MonoBehaviours.Input
{
    public abstract  class DeviceInput
    {
        public PlayerInput Input { get; }
        
        public DeviceInput(PlayerInput input)
        {
            Input = input;
            Input.Enable();
        }
        
        public abstract float GetVerticalAxis();
        public abstract float GetHorizontalAxis();
    }
}