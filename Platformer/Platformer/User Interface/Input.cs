using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Platformer.User_Interface
{
    class Input
    {

        public KeyboardState kb, old_kb;
        public bool shift_down, ctrl_down, alt_down;
        public bool shift_press, ctrl_press, alt_press;
        public bool old_shift_down, old_ctrl_down, old_alt_down;

        public Input() { }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Keypress(Keys k)
        {
            if (kb.IsKeyDown(k) && old_kb.IsKeyUp(k)) return true;
            else return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Keydown(Keys k)
        {
            if (kb.IsKeyDown(k)) return true;
            else return false;
        }


        public void Update()
        {

            old_alt_down = alt_down;
            old_ctrl_down = ctrl_down;
            old_shift_down = shift_down;
            old_kb = kb;
            kb = Keyboard.GetState();
            shift_down = false;
            ctrl_down = false;
            alt_down = false;
            shift_press = false;
            ctrl_press = false;
            alt_press = false;

            if (kb.IsKeyDown(Keys.LeftShift) || kb.IsKeyDown(Keys.RightShift)) { shift_down = true; }
            if (kb.IsKeyDown(Keys.LeftAlt) || kb.IsKeyDown(Keys.RightAlt)) { alt_down = true; }
            if (kb.IsKeyDown(Keys.LeftControl) || kb.IsKeyDown(Keys.RightControl)) { ctrl_down = true; }
            if (shift_down && !old_shift_down) { shift_press = true; }
            if (alt_down && !old_alt_down) { alt_press = true; }
            if (ctrl_down && !old_ctrl_down) { ctrl_press = true; }

        }
    }
}
