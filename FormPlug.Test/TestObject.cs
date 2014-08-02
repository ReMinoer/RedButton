﻿using System;
using System.Globalization;
using System.Text;
using FormPlug.Annotations;

namespace FormPlug.Test
{
    public class TestObject
    {
        [BooleanSocket(Group = "SocketAttribute", Name = "Boolean")]
        private bool Bool
        {
            [UsedImplicitly]
            get
            {
                return _bool;
            }
            set
            {
                _bool = value;
                if (BoolValueChanged != null)
                    BoolValueChanged(this, EventArgs.Empty);
            }
        }

        [NumericSocket(Group = "SocketAttribute", Name = "Integer", Minimum = -10, Maximum = 10, Increment = 2)]
        private int Int
        {
            [UsedImplicitly]
            get
            {
                return _int;
            }
            set
            {
                _int = value;
                if (IntValueChanged != null)
                    IntValueChanged(this, EventArgs.Empty);
            }
        }

        [NumericSocket(Group = "SocketAttribute", Name = "Decimal", Minimum = -1, Maximum = 1, Increment = 0.1,
            Decimals = 1)]
        private float Float
        {
            [UsedImplicitly]
            get
            {
                return _float;
            }
            set
            {
                _float = value;
                if (FloatValueChanged != null)
                    FloatValueChanged(this, EventArgs.Empty);
            }
        }

        [TextSocket(Group = "SocketAttribute", Name = "Text")]
        private string String
        {
            [UsedImplicitly]
            get
            {
                return _string;
            }
            set
            {
                _string = value;
                if (StringValueChanged != null)
                    StringValueChanged(this, EventArgs.Empty);
            }
        }

        [TextSocket(Group = "SocketAttribute", Name = "Long Text", Multiline = true, Width = 170, Height = 80)]
        private string BigString
        {
            [UsedImplicitly]
            get
            {
                return _bigString;
            }
            set
            {
                _bigString = value;
                if (BigStringValueChanged != null)
                    BigStringValueChanged(this, EventArgs.Empty);
            }
        }

        [DateTimeSocket(Group = "SocketAttribute", Name = "Enumeration")]
        private TestEnum Enum
        {
            [UsedImplicitly]
            get
            {
                return _enum;
            }
            set
            {
                _enum = value;
                if (EnumValueChanged != null)
                    EnumValueChanged(this, EventArgs.Empty);
            }
        }

        [DateTimeSocket(Group = "SocketAttribute", Name = "Date")]
        private DateTime DateTime
        {
            [UsedImplicitly]
            get
            {
                return _dateTime;
            }
            set
            {
                _dateTime = value;
                if (DateTimeValueChanged != null)
                    DateTimeValueChanged(this, EventArgs.Empty);
            }
        }

        private Socket<bool> BoolSocket { get; set; }
        private Socket<int> IntSocket { get; set; }
        private Socket<float> FloatSocket { get; set; }
        private Socket<string> StringSocket { get; set; }
        private Socket<string> BigStringSocket { get; set; }
        private Socket<TestEnum> EnumSocket { get; set; }
        private Socket<DateTime> DateTimeSocket { get; set; }

        private string _bigString;
        private bool _bool;
        private DateTime _dateTime;
        private TestEnum _enum;
        private float _float;
        private int _int;
        private string _string;

        public TestObject()
        {
            BoolSocket = new Socket<bool>
            {
                Attribute = new BooleanSocketAttribute {Group = "Socket<T>", Name = "Boolean"}
            };

            IntSocket = new Socket<int>
            {
                Attribute = new NumericSocketAttribute
                { Group = "Socket<T>", Name = "Integer", Minimum = -10, Maximum = 10, Increment = 2 }
            };

            FloatSocket = new Socket<float>
            {
                Attribute = new NumericSocketAttribute
                { Group = "Socket<T>", Name = "Decimal", Minimum = -1, Maximum = 1, Increment = 0.1, Decimals = 1 }
            };

            StringSocket = new Socket<string>
            {
                Attribute = new TextSocketAttribute {Group = "Socket<T>", Name = "Text"}
            };

            BigStringSocket = new Socket<string>
            {
                Attribute = new TextSocketAttribute
                { Group = "Socket<T>", Name = "Long Text", Multiline = true, Width = 170, Height = 80 }
            };

            EnumSocket = new Socket<TestEnum>
            {
                Attribute = new EnumSocketAttribute {Group = "Socket<T>", Name = "Enumeration"}
            };

            DateTimeSocket = new Socket<DateTime>
            {
                Attribute = new DateTimeSocketAttribute {Group = "Socket<T>", Name = "Date"}
            };

            Reset();
        }

        [UsedImplicitly]
        public event EventHandler BoolValueChanged;
        [UsedImplicitly]
        public event EventHandler IntValueChanged;
        [UsedImplicitly]
        public event EventHandler FloatValueChanged;
        [UsedImplicitly]
        public event EventHandler StringValueChanged;
        [UsedImplicitly]
        public event EventHandler BigStringValueChanged;
        [UsedImplicitly]
        public event EventHandler DateTimeValueChanged;
        [UsedImplicitly]
        public event EventHandler EnumValueChanged;

        public void Reset()
        {
            Bool = false;
            Int = 0;
            Float = 0;
            String = "";
            BigString = "";
            Enum = TestEnum.Yes;
            DateTime = DateTime.Now;

            BoolSocket.Value = false;
            IntSocket.Value = 0;
            FloatSocket.Value = 0;
            StringSocket.Value = "";
            BigStringSocket.Value = "";
            EnumSocket.Value = TestEnum.Yes;
            DateTimeSocket.Value = DateTime.Now;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(Bool.ToString());
            result.AppendLine(Int.ToString(CultureInfo.CurrentCulture));
            result.AppendLine(Float.ToString(CultureInfo.CurrentCulture));
            result.AppendLine(String);
            result.AppendLine(BigString);
            result.AppendLine(Enum.ToString());
            result.AppendLine(DateTime.ToString(CultureInfo.CurrentCulture));

            result.AppendLine(BoolSocket.Value.ToString());
            result.AppendLine(IntSocket.Value.ToString(CultureInfo.CurrentCulture));
            result.AppendLine(FloatSocket.Value.ToString(CultureInfo.CurrentCulture));
            result.AppendLine(StringSocket.Value);
            result.AppendLine(BigStringSocket.Value);
            result.AppendLine(EnumSocket.Value.ToString());
            result.AppendLine(DateTimeSocket.Value.ToString(CultureInfo.CurrentCulture));

            return result.ToString();
        }
    }
}