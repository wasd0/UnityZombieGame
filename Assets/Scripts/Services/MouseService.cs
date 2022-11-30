namespace Services
{
    public class MouseService : LookService
    {
        public override float GetHorizontalAxis()
        {
            return Input.Player.Look.ReadValue<float>();
        }
    }
}