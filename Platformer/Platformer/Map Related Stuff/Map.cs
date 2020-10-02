using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Monsters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Map_Related_Stuff
{
    class Map
    {
        public const int TILES_WIDE = 100;
        public const int TILES_HIGH = 50;
        public const int TILES_SPAN_X = 14;
        public const int TILE_SPAN_Y = 10;
        public Tile[,] tiles;
        public StartData startData;
        public Point loc;
        Sheet[] sheet;
        ProcessedTile[] overlapTiles;
        ProcessedTile[] crystals;
        Color crystal_color;
        int overlap_count, crystal_count;
        public Vector2 scroll_offset;
        public int a1, b1, a2, b2;
        public float sx, sy;
        Texture2D tiles_image;
        Vector2 screen_center;
        float timer;
        SpriteBatch spriteBatch;


        public Map(Sheet[] sht, SpriteBatch sprBatch)
        {
            sheet = sht;
            spriteBatch = sprBatch;
            tiles = new Tile[TILES_WIDE, TILES_HIGH];

            for (int i = 0; i < TILES_HIGH; i++)
            {
                for (int j = 0; j < TILES_WIDE; j++)
                {
                    tiles[i, j] = new Tile(0, TileType.empty);
                }
            }
            overlapTiles = new ProcessedTile[250];
            crystals = new ProcessedTile[250];
            for (int i = 0; i < 250; i++){ overlapTiles[i] = new ProcessedTile(); }
            for (int i = 0; i < 250; i++) { crystals[i] = new ProcessedTile(); }

            loc.X = 5;
            loc.Y = 5;
            startData = new StartData(loc.X, loc.Y);
            screen_center = Game1.screen_center;
        }


        public void SetTilesImage(Texture2D tilesPic)
        {
            tiles_image = tilesPic;
        }


        public void DeleteTile()
        {
            int n = tiles[loc.X, loc.Y].index;
            for (int i = loc.Y; i < loc.Y + sheet[n].tiles_high; i++)
            {
                if(i >= (TILES_HIGH - 1)) { break;}
                for (int j = loc.X; j < loc.X + sheet[n].tiles_wide; j++)
                {
                    if(j >= (TILES_WIDE - 1)) break;
                    tiles[i, j].Clear();
                }
            }
        }

        public void ClearMap()
        {
            for (int i = 0; i < TILES_HIGH; i++)
            {
                for (int j = 0; j < TILES_WIDE; j++)
                {
                    tiles[i, j].Clear();
                }
            }
        }



        public void AddTile(int n)
        {
            DeleteTile();
            tiles[loc.X, loc.Y].index = n;
            tiles[loc.X, loc.Y].offset = sheet[n].offset;
            for (int i = loc.Y; i <loc.Y+sheet[n].tiles_high ; i++)
            {
                if(i >= (TILES_HIGH - 1)) { break; }
                for (int j = loc.X; j < loc.X + sheet[n].tiles_wide; j++)
                {
                    if(j >= (TILES_WIDE - 1)) { break;}
                    TileType type = sheet[i].type;
                    tiles[i, j].type = type;
                
                    if((type == TileType.solid) || (type == TileType.spring) || (type == TileType.platform) || (type == TileType.spikes)) {

                        tiles[i, j].overlap = true;
                        tiles[i, j].stand_on = true;
                        if(type == TileType.spikes)
                        {
                            tiles[i, j].spikes = true;
                            tiles[i,j].is_solid = true;
                        }
                        else if(type == TileType.solid)
                        {
                            tiles[i, j].is_solid = true;
                        }
                    }                 
                }
            }
        }



        public void SetType(TileType type = TileType.solid)
        {
            int a = loc.X;
            int b = loc.Y;
            tiles[a, b].type = type;
            if ((tiles[a, b].type == TileType.solid) || (tiles[a, b].type == TileType.spring) || (tiles[a, b].type == TileType.platform) || (tiles[a,b].type == TileType.spikes)) {
                tiles[a, b].overlap = true;
                tiles[a,b].stand_on = true;
                if(type == TileType.spikes)
                {
                    tiles[a,b].spikes = true;
                    tiles[a, b].is_solid = true;
                }
                else if(type == TileType.solid)
                {
                    tiles[a,b].is_solid = true;
                }
            }
        }


        public void SetMonster(MonsterType monster)
        {
            tiles[loc.X, loc.Y].monster_start = monster;
        }


        public void AddBorder(int n)
        {
            for (int i = 0; i < TILES_WIDE; i++)
            {
                loc.X = i;
                loc.Y = 0;
                AddTile(n);
                loc.Y = TILES_HIGH - 1;
                AddTile(n);
            }
            for (int i = 0; i < TILES_HIGH; i++)
            {
                loc.X = 0;
                loc.Y = i;
                AddTile(n);
                loc.X = TILES_WIDE - 1;
                AddTile(n);
            }
        }



    }
}
