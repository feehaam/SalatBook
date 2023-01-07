namespace DataAccessLayer.IRepository
{
    public interface IHelperRepo
    {
        bool StudentExists(string name);
        bool Save();
    }
}
