namespace Application.Exceptions
{
    public class RecordDBDataConfigurationNotFoundException : ApplicationException
    {
        public RecordDBDataConfigurationNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
        {

        }
    }
}
