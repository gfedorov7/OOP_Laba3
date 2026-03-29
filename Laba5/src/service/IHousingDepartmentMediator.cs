
namespace Laba5.service
{
    /// <summary>
    /// Интерфейс медиатора между формой и бизнес-логикой.
    /// </summary>
    public interface IHousingDepartmentMediator
    {
        public void SaveField(int fieldIndex, string textValue, decimal numericValue, string residentNames,
            string residentHouses);
        public void ToggleInfo();
        public void ShowField(int fieldIndex);
    }
}