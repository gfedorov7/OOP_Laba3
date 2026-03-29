using Laba5.service;
using Laba5.Src.Subject;
using Laba5.Src.util;

namespace Laba5.src
{
    /// <summary>
    /// Единственный медиатор для взаимодействия формы <see cref="Form1"/> с моделью <see cref="HousingDepartment"/>.
    /// Отвечает за управление видимостью полей ввода, сохранение данных и отображение информации о департаменте.
    /// </summary>
    public class HousingDepartmentMediator : IHousingDepartmentMediator
    {
        /// <summary>
        /// Ссылка на форму, с которой работает медиатор.
        /// </summary>
        private readonly Form1 _form;

        /// <summary>
        /// Ссылка на модель департамента жилья (Singleton).
        /// </summary>
        private readonly HousingDepartment _department;

        /// <summary>
        /// Флаг, указывающий, отображена ли информация о департаменте.
        /// </summary>
        private bool _isInfoShown = false;

        /// <summary>
        /// Инициализирует новый экземпляр медиатора для указанной формы.
        /// </summary>
        /// <param name="form">Форма <see cref="Form1"/>, с которой будет работать медиатор.</param>
        public HousingDepartmentMediator(Form1 form)
        {
            _form = form;
            _department = HousingDepartment.Instance;
        }

        /// <summary>
        /// Сохраняет данные в модель в зависимости от выбранного поля.
        /// </summary>
        /// <param name="fieldIndex">Индекс поля, выбранного в ComboBox.</param>
        /// <param name="textValue">Текстовое значение для поля.</param>
        /// <param name="numericValue">Числовое значение для поля.</param>
        /// <param name="residentNames">Строка с именами жильцов (через ;).</param>
        /// <param name="residentHouses">Строка с номерами домов жильцов (через ;).</param>
        public void SaveField(int fieldIndex, string textValue, decimal numericValue, string residentNames, string residentHouses)
        {
            try
            {
                switch (fieldIndex)
                {
                    case 0: _department.District = textValue; break;
                    case 1: _department.HousingDepartmentNumber = (int)numericValue; break;
                    case 2: _department.Residents = ParseResidents(residentNames, residentHouses); break;
                    case 3: _department.PaidResidentsCount = (int)numericValue; break;
                    case 4: _department.Tariff = (double)numericValue; break;
                    case 5: _department.Balance = numericValue; break;
                    case 6: _department.EmployeeCount = (int)numericValue; break;
                }

                _form.label_saved_status.Visible = true;
                _form.label_show_info.Text = _department.ToString();
                _isInfoShown = true;
                _form.button_show.Text = "Скрыть информацию";
            }
            catch (Exception ex)
            {
                NativeMessageBox.MessageBox(
                    IntPtr.Zero,
                    ex.Message,
                    "Ошибка",
                    NativeMessageBox.MB_OK | NativeMessageBox.MB_ICONERROR
                );
            }
        }

        /// <summary>
        /// Переключает отображение информации о департаменте между скрытой и видимой.
        /// </summary>
        public void ToggleInfo()
        {
            if (_isInfoShown)
            {
                _form.label_show_info.Text = "";
                _form.button_show.Text = "Показать информацию";
            }
            else
            {
                _form.label_show_info.Text = _department.ToString();
                _form.button_show.Text = "Скрыть информацию";
            }

            _isInfoShown = !_isInfoShown;
        }

        /// <summary>
        /// Управляет видимостью полей ввода в зависимости от выбранного индекса.
        /// </summary>
        /// <param name="fieldIndex">Индекс выбранного поля в ComboBox.</param>
        public void ShowField(int fieldIndex)
        {
            // Скрываем все поля ввода
            _form.textBox_district.Visible = false;
            _form.numericUpDown_housingDepartmentNumber.Visible = false;
            _form.textBox_residentName.Visible = false;
            _form.textBox_residentHouseNum.Visible = false;
            _form.numericUpDown_paidResidentsCount.Visible = false;
            _form.numericUpDown_tariff.Visible = false;
            _form.numericUpDown_balance.Visible = false;
            _form.numericUpDown_employeeCount.Visible = false;

            // Отображаем только выбранное поле
            switch (fieldIndex)
            {
                case 0: _form.textBox_district.Visible = true; break;
                case 1: _form.numericUpDown_housingDepartmentNumber.Visible = true; break;
                case 2:
                    _form.textBox_residentName.Visible = true;
                    _form.textBox_residentHouseNum.Visible = true;
                    break;
                case 3: _form.numericUpDown_paidResidentsCount.Visible = true; break;
                case 4: _form.numericUpDown_tariff.Visible = true; break;
                case 5: _form.numericUpDown_balance.Visible = true; break;
                case 6: _form.numericUpDown_employeeCount.Visible = true; break;
            }
        }

        /// <summary>
        /// Преобразует строки с именами и номерами домов жильцов в массив <see cref="Resident"/>.
        /// </summary>
        /// <param name="names">Строка с именами жильцов, разделёнными ;</param>
        /// <param name="numbers">Строка с номерами домов, разделёнными ;</param>
        /// <returns>Массив объектов <see cref="Resident"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">Если количество имен и номеров домов не совпадает.</exception>
        private Resident[] ParseResidents(string names, string numbers)
        {
            var splitNames = names.Split(';');
            var splitNumbers = numbers.Split(';');

            if (splitNames.Length != splitNumbers.Length)
                throw new IndexOutOfRangeException();

            Resident[] residents = new Resident[splitNames.Length];
            for (int i = 0; i < splitNames.Length; i++)
            {
                residents[i] = new Resident(int.Parse(splitNumbers[i]), splitNames[i]);
            }

            return residents;
        }
    }
}