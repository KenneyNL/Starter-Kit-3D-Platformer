# 📦 ASSET ORGANIZATION GUIDE

This guide will help you organize your downloaded Kenney assets into the correct folders.

---

## 🎯 QUICK START

1. **Check the folder structure** - All folders have been created for you!
2. **Read the README.md** in each folder to understand what goes there
3. **Drag and drop** your Kenney assets into the appropriate folders
4. **Commit and push** to Git when done
5. **Let me know** and I'll verify everything loaded correctly!

---

## 📂 FOLDER STRUCTURE OVERVIEW

```
Starter-Kit-3D-Platformer/
│
├── models/                          # 3D Models (.glb, .gltf)
│   ├── characters/
│   │   ├── player/                 # Player model (already exists)
│   │   └── enemies/                # 📖 Enemy models → Read README
│   │
│   ├── platforms/                   # 📖 Platform models → Read README
│   ├── collectibles/
│   │   └── fruits/                 # 📖 Fruit models (Food Kit) → Read README
│   │
│   ├── obstacles/                   # 📖 Crates, spikes, springs → Read README
│   └── environment/
│       ├── jungle/                 # 📖 Trees, rocks, ruins → Read README
│       └── props/                  # 📖 Checkpoints, flags → Read README
│
├── sprites/                         # 2D Images (.png)
│   ├── ui/
│   │   ├── icons/                  # 📖 Life, fruit, star icons → Read README
│   │   ├── touch_controls/         # 📖 Mobile controls → Read README
│   │   └── panels/                 # 📖 UI backgrounds → Read README
│   └── effects/                    # Particle sprites
│
├── sounds/                          # Audio Files (.ogg)
│   ├── player/                     # 📖 Spin, hurt, death → Read README
│   ├── collectibles/               # 📖 Fruit collect, life gain → Read README
│   ├── obstacles/                  # 📖 Crate break, spring → Read README
│   ├── enemies/                    # 📖 Enemy sounds → Read README
│   ├── ui/                         # 📖 Button clicks → Read README
│   ├── level/                      # 📖 Checkpoint, victory → Read README
│   └── music/                      # 📖 Background music (optional) → Read README
│
├── objects/                         # Godot Scenes (.tscn)
│   └── (We'll create these together after assets are imported)
│
├── scenes/                          # Game Scenes
│   └── (We'll create these together)
│
└── scripts/                         # GDScript Files
    └── (We'll create these together)
```

---

## ✅ ASSET CHECKLIST

### 🔴 HIGH PRIORITY (Need these to start):

#### From **FOOD KIT**:
- [ ] 3-5 fruit models (.glb) → `models/collectibles/fruits/`
  - apple.glb, orange.glb, banana.glb, etc.

#### From **PLATFORMER KIT**:
- [ ] Crate models (.glb) → `models/obstacles/`
  - crate.glb (basic wooden crate)
- [ ] Spring/bounce pad (.glb) → `models/obstacles/`
  - spring_pad.glb or spring.glb
- [ ] Spike trap (.glb) → `models/obstacles/`
  - spike.glb or spike_trap.glb
- [ ] Checkpoint model (.glb) → `models/environment/props/`
  - checkpoint.glb or flag_checkpoint.glb

#### From **UI PACK** (or Game Icons):
- [ ] Life/heart icon (.png) → `sprites/ui/icons/`
  - icon_life.png or icon_heart.png
- [ ] Fruit icon (.png) → `sprites/ui/icons/`
  - icon_fruit.png
- [ ] Star icon (.png) → `sprites/ui/icons/`
  - icon_star.png
- [ ] Pause button (.png) → `sprites/ui/icons/`
  - button_pause.png

---

### 🟡 MEDIUM PRIORITY (Good to have):

#### From **CHARACTER PACK**:
- [ ] 2-3 enemy models (.glb) → `models/characters/enemies/`
  - Rename to: enemy_patroller.glb, enemy_spinner.glb

#### From **PLATFORMER KIT**:
- [ ] Additional platform variants → `models/platforms/`
- [ ] More obstacle types → `models/obstacles/`

#### From **NATURE KIT** (if downloaded):
- [ ] Trees, rocks, plants → `models/environment/jungle/`

---

### 🟢 LOW PRIORITY (Polish & optional):

#### Sound Effects:
- [ ] Spin attack sound → `sounds/player/`
- [ ] Hurt/death sounds → `sounds/player/`
- [ ] Fruit collect sound → `sounds/collectibles/`
- [ ] Checkpoint sound → `sounds/level/`
- [ ] Victory fanfare → `sounds/level/`

#### UI Assets:
- [ ] Touch control sprites → `sprites/ui/touch_controls/`
- [ ] Panel backgrounds → `sprites/ui/panels/`

#### Environment:
- [ ] Decorative props → `models/environment/`

---

## 🔧 GODOT IMPORT SETTINGS (AFTER copying files)

Once you've copied assets into folders:

1. **Open Godot 4.5**
2. **Let it auto-import** (may take a few minutes)
3. **Check 3D models**:
   - Click on a `.glb` file in FileSystem
   - Check "Import" tab
   - Ensure scale looks correct (usually 1.0)
4. **Check textures**:
   - Icons should be "Lossy" or "Lossless" compression
   - Enable "Mipmaps" for 3D textures
5. **Check audio**:
   - Format: OggVorbis
   - Loop: OFF (for sound effects), ON (for music)

---

## 📝 FILE NAMING TIPS

When copying files from Kenney packs, rename them to be clear:

### Good naming:
- `apple.glb` ✓
- `crate.glb` ✓
- `enemy_patroller.glb` ✓
- `icon_life.png` ✓

### Bad naming:
- `food_03.glb` ✗ (unclear)
- `obj_45.glb` ✗ (unclear)
- `asset.glb` ✗ (too generic)

**Use lowercase with underscores!**

---

## 🚀 NEXT STEPS

### After organizing assets:

1. **Commit to Git:**
   ```bash
   git add models/ sprites/ sounds/
   git commit -m "Add Kenney asset packs (Platformer, Food, Character, UI)"
   git push -u origin claude/godot-crash-platformer-011CUjb3gBpfQk8UcwrEPXaX
   ```

2. **Tell Claude:** "Assets synced!"

3. **Claude will:**
   - Verify all assets imported correctly
   - Start building game systems
   - Create scene files (.tscn) for each asset
   - Build the complete Level 1 experience!

---

## ❓ QUESTIONS?

- **Don't have a specific asset?** → Skip it! We can work around it or use placeholders
- **Unsure which file to use?** → Check the README.md in each folder
- **Multiple variants of same asset?** → Pick one, or include all variants!
- **Can't find Kenney sounds?** → We can use free sounds from freesound.org later

---

## 📄 LICENSE & ATTRIBUTION

All Kenney assets are **CC0 1.0 Universal (Public Domain)**
Source: https://kenney.nl/

You can use them freely in your game, commercial or not!

---

**Ready to start? Open your Kenney asset downloads and start dragging files into the folders!** 🎮
