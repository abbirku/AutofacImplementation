
//Just a basic implementation for maintaining structure
namespace Core
{
    /*
     * Note: Need to improve IEntity by providing Generic type for Id as IEntity<T> 
     * **/
    public interface IEntity
    {
        public int Id { get; set; }
    }
}
