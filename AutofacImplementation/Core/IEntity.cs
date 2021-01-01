namespace Core
{
    /*
     * Notes:
     * ------
     * 1. Need to improve IEntity by providing Generic type for Id as "IEntity<TKey>" and "public TKey Id { get; set; }"
     * 2. Just a basic implementation for maintaining DevSkill structure.
     * **/
    public interface IEntity
    {
        public int Id { get; set; }
    }
}
