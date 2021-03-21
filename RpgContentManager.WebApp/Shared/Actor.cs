namespace RpgContentManager.WebApp
{
    public class Actor : BaseModel
    {
        public string Name { get; set; }

        public ActorType ActorType { get; set; }
    }
}
