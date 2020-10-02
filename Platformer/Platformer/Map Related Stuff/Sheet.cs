using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Map_Related_Stuff
{
    class Sheet
    {
        public TileType type;
        public Rectangle rect;
        public int tiles_wide, tiles_high;
        public Vector2 offset;

        public Sheet(int x, int y, int x2, int y2, TileType Type, int Tiles_wide, int Tiles_high, float top_left_corner_x, float top_left_corner_y)
        {
            int width = x2 - x + 1;
            int height = y2 - y + 1;
            rect = new Rectangle(x, y, width, height);
            type = Type;
            tiles_wide = Tiles_wide;
            tiles_high = Tiles_high;
            offset = new Vector2(rect.X, rect.Y) - new Vector2(top_left_corner_x, top_left_corner_y);
        }




    }


    class SheetManager
    {

        int num_sheet_parts;
        public SheetManager() { num_sheet_parts = 0; }

        public void Setup_Sheet_Level_1(ref Sheet[] sheet)
        {
            num_sheet_parts = 0;
            int n = 0;
            sheet[n] = new Sheet(0, 0, 1, 1, TileType.empty, 1, 1, 0f, 0f); n++;              // nothing 0
            sheet[n] = new Sheet(0, 16, 255, 111, TileType.solid, 4, 1, 0f, 32f); n++;        // grass1 1 q
            sheet[n] = new Sheet(0, 128, 127, 255, TileType.solid, 2, 2, 0f, 128f); n++;      // solid block (green) 2 w
            sheet[n] = new Sheet(166, 128, 344, 255, TileType.spring, 1, 1, 224f, 160f); n++; // spring (leaves) 3 e
            sheet[n] = new Sheet(448, 128, 575, 254, TileType.reflector, 1, 1, 480f, 160f); n++; // reflective crystals 4 r
            sheet[n] = new Sheet(768, 128, 959, 319, TileType.solid, 3, 3, 768f, 128f); n++;  // big solid block 5 t
            sheet[n] = new Sheet(0, 320, 63, 383, TileType.solid, 1, 1, 0f, 320f); n++;       // small solid block 6 y
            sheet[n] = new Sheet(65, 321, 127, 383, TileType.empty, 1, 1, 64f, 320f); n++;    // leaf decoration 7 u
            sheet[n] = new Sheet(131, 256, 213, 383, TileType.empty, 1, 1, 146f, 320f); n++;  // rose 8 i
            sheet[n] = new Sheet(320, 256, 447, 383, TileType.solid, 2, 2, 320f, 256f); n++;  // gold block 9 o
            sheet[n] = new Sheet(0, 512, 127, 639, TileType.solid, 2, 2, 0f, 512f); n++;      // green-yellow block 10 p
            sheet[n] = new Sheet(128, 512, 256, 639, TileType.solid, 2, 2, 128f, 512f); n++;  // green-solid block 11 a
            sheet[n] = new Sheet(257, 402, 511, 650, TileType.empty, 1, 1, 367f, 576f); n++;  // house 12 s
            sheet[n] = new Sheet(576, 448, 702, 639, TileType.empty, 1, 1, 593f, 569f); n++;   // big rose 13 d
            sheet[n] = new Sheet(704, 384, 911, 646, TileType.empty, 1, 1, 772f, 576f); n++;   // tree 14 f
            sheet[n] = new Sheet(0, 448, 63, 479, TileType.platform, 1, 1, 0, 448); n++;       // platform 15 g            
            sheet[n] = new Sheet(768, 704, 895, 831, TileType.spikes, 2, 2, 768, 704); n++;    // spikes 16 h 

            num_sheet_parts = n;
        }
    }
}
