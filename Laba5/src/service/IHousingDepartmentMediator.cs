namespace Laba1.service;

/// <summary>
/// Интерфейс посредника для управления жилищным департаментом.
/// </summary>
public interface IHousingDepartmentMediator
{
    /// <summary>Обновляет район.</summary>
    void UpdateDistrict(string district);

    /// <summary>Обновляет номер департамента.</summary>
    void UpdateHousingDepartmentNumber(int housingDepartmentNumber);

    /// <summary>Обновляет жильцов.</summary>
    void UpdateResidents(string names, string houseNumbers);

    /// <summary>Обновляет количество оплативших жильцов.</summary>
    void UpdatePaidResidentsCount(int paidResidentsCount);

    /// <summary>Обновляет тариф.</summary>
    void UpdateTariff(double tariff);

    /// <summary>Обновляет баланс.</summary>
    void UpdateBalance(decimal balance);

    /// <summary>Обновляет количество сотрудников.</summary>
    void UpdateEmployeeCount(int employeeCount);

    /// <summary>Возвращает информацию о департаменте.</summary>
    string GetDepartmentInfo();
}