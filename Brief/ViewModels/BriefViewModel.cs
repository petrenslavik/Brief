using System;
using System.Collections;
using System.Collections.Generic;
using Brief.Attributes;
using Brief.Models;

namespace Brief.ViewModels
{
    public class BriefViewModel
    {
        public IEnumerable<Section> Sections => new List<Section>()
        {
            new Section()
            {
                Name = "Расскажите о Себе и Своей организации",
                Fields = new BaseField[]
                {
                    new TextField()
                    {
                        Name = "Name",
                        Question = "Ваше имя"
                    },
                    new TextField()
                    {
                        Name = "Email",
                        Question = "Ваша электронная почта"
                    },
                    new TextField()
                    {
                        Name = "PhoneNumber",
                        Question = "Ваш номер телефона"
                    },
                    new TextField()
                    {
                        Name = "OrganizationName",
                        Question = "Название Вашей организации"
                    }
                },
            },
            new Section()
            {
                Name = "Расскажите о программном обеспечении, которое Вам требуется",
                Fields = new BaseField[]
                {
                    new TextField()
                    {
                        Name = "SoftwareType",
                        Question = "Тип программного обеспечения"
                    },
                    new TextField()
                    {
                        Name = "Problem",
                        Question =
                            "Какую проблему (Вашей организации или Ваших клиентов) призвано решить данное программное обеспечение?"
                    },
                    new TextField()
                    {
                        Name = "Analog",
                        Question = "Приведите несколько примеров аналогичного программного обеспечения"
                    },
                    new TextField()
                    {
                        Name = "UseCaseGeography",
                        Question = "География использования программного обеспечения"
                    }
                }
                },
            new Section()
            {
                Name = "Разработка ПО",
                Fields = new BaseField[]
                {
                    new SwitchField()
                    {
                        Name = "IsDesignRequired",
                        Question = "Имеете ли вы готовый дизайн для данного программного обеспечения?"
                    },
                    new SwitchField()
                    {
                        Name = "IsStyleExist",
                        Question = "Имеет ли Ваша организация фирменный стиль, логотип, символику?"
                    },
                    new SwitchField()
                    {
                        Name = "ContinuousMaintenance",
                        Question =
                            "Требуется ли Вам дальнейшая поддержка данного программного обеспечения силами нашей компании?"
                    }
                }
            },
            new Section()
            {
                Name = "Ресурсы",
                Fields = new BaseField[]
                {
                    new DateField()
                    {
                        Name = "DesirableDeadline",
                        Question = "Укажите желаемые сроки готовности данного программного обеспечения"
                    }
                }
            }
        };


        //[Field("Укажите приблизительный бюджет для разработки данного программного обеспечения (от $ - до $)")]
        //public long ApproximateBudget { get; set; }
    }

    public class Section
    {
        public IEnumerable<BaseField> Fields { get; set; }

        public string Name { get; set; }
    }
}
