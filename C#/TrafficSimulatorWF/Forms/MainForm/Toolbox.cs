using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Modify
using System.Windows.Forms;
using System.Drawing;

namespace TrafficSimulatorWF.Forms.MainForm
{
    static class Toolbox
    {
        //================================================
        //Поля
        //================================================

        //Цвета
        static private Color _colorOn = System.Drawing.Color.Gray;
        static private Color _colorOff = System.Drawing.Color.White;

        //Список инструментов
        static private List<Control> _toolControls = new List<Control>();

        //Активный инструмент
        static private int _toolActive = 0;

        //================================================
        //События
        //================================================

        static private void ToolClick(object sender, System.EventArgs e)
        {
            SetTool((Control)sender);
        }

        //================================================
        //Методы
        //================================================

        //Добавить инструмент
        static public void AddTool(Control control)
        {
            //Изменить цвет
            control.BackColor = _colorOff;

            //Добавляем в список
            _toolControls.Add(control);

            //Добавляем событие
            control.Click += ToolClick;
        }

        //Установить активный инструмент
        static public void SetTool(Control control)
        {
            //Изменить цвет
            _toolControls[_toolActive].BackColor = _colorOff;
            control.BackColor = _colorOn;

            //Устанавливаем индекс
            _toolActive = _toolControls.IndexOf(control);
        }

        //Проверить активен ли инструмент
        static public bool CheckTool(Control control)
        {
            return (_toolActive == _toolControls.IndexOf(control));
        }
    }
}
