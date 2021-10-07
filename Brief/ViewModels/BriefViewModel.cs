using System;
using Brief.Attributes;

namespace Brief.ViewModels
{
    public class BriefViewModel
    {
        [Field("Ваше имя")]
        public string Name { get; set; }

        [Field("Ваша электронная почта")]
        public string Email { get; set; }

        [Field("Ваш номер телефона")]
        public string PhoneNumber { get; set; }

        [Field("Название Вашей организации")]
        public string OrganizationName { get; set; }

        [Field("Тип программного обеспечения")]
        public string SoftwareType { get; set; }

        [Field("Какую проблему (Вашей организации или Ваших клиентов) призвано решить данное программное обеспечение?")]
        public string Problem { get; set; }

        [Field("Приведите несколько примеров аналогичного программного обеспечения")]
        public string Analog { get; set; }

        [Field("География использования программного обеспечения")]
        public string UseCaseGeography { get; set; }

        [Field("Имеете ли вы готовый дизайн для данного программного обеспечения?")]
        public bool IsDesignRequired { get; set; }

        [Field("Имеет ли Ваша организация фирменный стиль, логотип, символику?")]
        public bool IsStyleExist { get; set; }

        [Field("Требуется ли Вам дальнейшая поддержка данного программного обеспечения силами нашей компании?")]
        public bool ContinuousMaintenance { get; set; }

        [Field("Укажите желаемые сроки готовности данного программного обеспечения")]
        public DateTime DesirableDeadline { get; set; }

        [Field("Укажите приблизительный бюджет для разработки данного программного обеспечения (от $ - до $)")]
        public long ApproximateBudget { get; set; }
    }
}
