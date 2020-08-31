namespace Assets.Scripts
{
    public interface IBehaviourJump
    {
        void Jump();

        bool IsJumpPressed { get; set; }
    }
}
