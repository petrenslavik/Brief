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
                        Question = "Имя контактного лица",
                        IsMandatory = true,
                        MinLength = 3,
                        MaxLength = 120
                    },
                    new TextField()
                    {
                        Name = "Email",
                        Question = "Электронная почта",
                        IsMandatory = true,
                        MinLength = 3,
                        MaxLength = 120
                    },
                    new TextField()
                    {
                        Name = "PhoneNumber",
                        Question = "Номер телефона",
                        IsMandatory = true,
                        MinLength = 3,
                        MaxLength = 120
                    },
                    new TextField()
                    {
                        Name = "Messenger",
                        Question = "Любой месенджер (Telegram, Viber)",
                        IsMandatory = false,
                        MinLength = 3,
                        MaxLength = 120
                    },
                    new TextField()
                    {
                        Name = "ConvenientTime",
                        Question = "Удобное время для связи",
                        IsMandatory = false,
                        MinLength = 2,
                        MaxLength = 100
                    },
                    new TextField()
                    {
                        Name = "OrganizationName",
                        Question = "Название организации",
                        IsMandatory = true,
                        MinLength = 3,
                        MaxLength = 120
                    },
                    new TextAreaField()
                    {
                        Name = "OrganizationDescription",
                        Question = "Чем занимается Ваша организация?",
                        IsMandatory = true
                    },
                    new TextAreaField()
                    {
                        Name = "Features",
                        Question = "Какие особенности Вашего товара/услуг?",
                        IsMandatory = false
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
                     new TextAreaField()
                    {
                        Name = "Structure",
                        Question = "Напишите предварительную структуру сайта: основные разделы, подразделы. Кратко опишите их функциональное назначение и дайте характеристику содержания каждого из разделов.",
                        IsMandatory = true
                    },
                    new TextAreaField()
                    {
                        Name = "Customers",
                        Question = "Кто будут вашими основными клиентами? (Пол, возраст, доход, стиль жизни и т.д.)",
                        IsMandatory = false
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
                    },
                    new RadioField()
                    {
                        Name = "ApproximateBudget",
                        Question = "Укажите приблизительный бюджет для разработки данного программного обеспечения (от $ - до $)",
                        IsMandatory = true,
                        Options = new string[]{"До 50000", "От 50000 до 100000", "Больше 100000" },
                    }
                }
            },
            new Section()
            {
                Name = "Дополнительная информация",
                Fields = new BaseField[]
                {
                   new TextAreaField()
                    {
                        Name = "AdditionalInformation",
                        Question = "Здесь вы можете оставить любую полезную информацию для проекта. Или задать свои вопросы.",
                        IsMandatory = false
                    },
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
