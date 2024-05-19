namespace Lesson_12_2;
internal class Program
{  
    public class MenuItem
    {
        public string? Caption;
        public string? HotKey;
        public MenuItem[]? Items;
    }

    public static MenuItem[] GenerateMenu()
    {
        return new[] {
            new MenuItem
            {
                Caption = "File",
                HotKey = "F",
                Items = new MenuItem[]
                {
                    new MenuItem
                    {
                        Caption = "New",
                        HotKey = "N",
                        Items = null
                    },

                    new MenuItem
                    {
                        Caption = "Save",
                        HotKey = "S",
                        Items = null
                    }
                }
            },

            new MenuItem
            {
                Caption = "Edit",
                HotKey = "E",
                Items = new MenuItem[]
                {
                    new MenuItem
                    {
                        Caption = "Copy",
                        HotKey = "C",
                        Items = null
                    },

                    new MenuItem
                    {
                        Caption = "Paste",
                        HotKey = "V",
                        Items = null
                    }
                }
            }
        };
    }
}
