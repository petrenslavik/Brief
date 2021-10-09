using System;
using System.Collections;
using System.Collections.Generic;
using Brief.Attributes;
using Brief.Models;

namespace Brief.ViewModels
{
    public class BriefViewModel
    {
        public IEnumerable<Section> Sections => new Section[]
        {
            new Section()
            {
                Name = "Расскажите о Себе и Своей организации",
                Fields = new BaseField[]
                {
                    new TextField()
                    {
                        Name = "Name",
                        Question = "Ваше имя",
                        IsMandatory = true,
                        MinLength = 3,
                        MaxLength = 120
                    },
                    new TextField()
                    {
                        Name = "Email",
                        Question = "Ваша электронная почта",
                        IsMandatory = true,
                        MinLength = 3,
                        MaxLength = 120
                    },
                    new TextField()
                    {
                        Name = "PhoneNumber",
                        Question = "Ваш номер телефона",
                        IsMandatory = true,
                        MinLength = 3,
                        MaxLength = 120
                    },
                    new TextField()
                    {
                        Name = "OrganizationName",
                        Question = "Название Вашей организации",
                        IsMandatory = true,
                        MinLength = 3,
                        MaxLength = 120
                    },
                    new TextAreaField()
                    {
                        Name = "OrganizationDescription",
                        Question = "Чем занимается Ваша организация?",
                        IsMandatory = true
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
                        Question = "Тип программного обеспечения",
                        IsMandatory = true,
                        MinLength = 3,
                        MaxLength = 120
                    },
                    new TextAreaField()
                    {
                        Name = "Problem",
                        Question =
                            "Какую проблему (Вашей организации или Ваших клиентов) призвано решить данное программное обеспечение?",
                        IsMandatory = true
                    },
                    new TextAreaField()
                    {
                        Name = "Analog",
                        Question = "Приведите несколько примеров аналогичного программного обеспечения",
                        IsMandatory = true
                    },
                    new RadioField()
                    {
                        Name = "UseCaseGeography",
                        Question = "География использования программного обеспечения",
                        Options = new string[]{"Местная","Региональная","Национальная","Международная"}
                    }
                }
                },
            new Section()
            {
                Name = "Разработка ПО",
                Fields = new BaseField[]
                {
                    new RadioField()
                    {
                        Name = "IsDesignRequired",
                        Question = "Имеете ли вы готовый дизайн для данного программного обеспечения?",
                        Options = new string[]{"Да", "Нет"},
                        IsMandatory = true
                    },
                    new RadioField()
                    {
                        Name = "IsStyleExist",
                        Question = "Имеет ли Ваша организация фирменный стиль, логотип, символику?",
                        Options = new string[]{"Да", "Нет"},
                        IsMandatory = true
                    },
                    new RadioField()
                    {
                        Name = "ContinuousMaintenance",
                        Question = "Требуется ли Вам дальнейшая поддержка данного программного обеспечения силами нашей компании?",
                        Options = new string[]{"Да", "Нет"},
                        IsMandatory = true
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
                        Question = "Укажите желаемые сроки готовности данного программного обеспечения",
                        IsMandatory = true
                    }
                }
            }
        };
    }

    public class Section
    {
        public IEnumerable<BaseField> Fields { get; set; }

        public string Name { get; set; }
    }
}
