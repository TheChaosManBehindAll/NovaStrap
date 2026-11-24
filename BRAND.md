# 🪐 NovaStrap — brand & identity guide

This is the official identity of the project. Follow it and every screenshot, badge and repo surface reads like one product.

## The name

| Rule | Detail |
|---|---|
| Written form | **NovaStrap** — always capitalised, one word. Never `NOVASTRAP` in prose, never `novastrap` as the product name (lowercase is reserved for URLs, file names and topics). |
| Pronunciation | **NO-vah-strap** |
| Executable | `NovaStrap.exe` |
| Installer | `NovaStrap-Setup-<version>-win-x64.exe` |
| Repository | `TheChaosManBehindAll/NovaStrap` |
| Tagline | **Chaos, in orbit.** |

### The story (use it anywhere the name needs explaining)

A nova is a dead-star detonation — a white dwarf goes thermonuclear, blows its outer layers into an expanding, glowing ring and briefly outshines its entire galaxy. The emblem shows the same composition: a dark client square wrapped in a crimson blast ring. NovaStrap wraps Roblox the same way — your client, your orbit, pure chaos harnessed.

## Voice

Hype, but honest. The brand voice is chaos vocabulary — *orbit, command deck, boss fight, receipts* — anchored by the project's honesty contract: every feature is labelled **live**, **partial** or **planned**, and we hype what we ship, nothing else. Friendly to other launchers (Bloxstrap built this category and gets respect), aggressive about what NovaStrap itself does next.

## Palette

Sampled directly from the official emblem on 2026-11-24 (`scripts/sample_emblem_colors.py`, 600 770 opaque pixels measured):

| Role | Name | Hex | Where it is used |
|---|---|---|---|
| Primary accent | **Nova Red** | `#F30E1A` | App accent colour, badges, links, highlights, primary buttons |
| Deep accent | **Deep Crimson** | `#D70B15` | Gradients, hover / pressed states, secondary accent |
| App background | **Graphite** | `#0C0C10` | Window / interface background |
| Art background | **Void Black** | `#101010` | Artwork, hero images, emblem surroundings |
| Text | White / graphite greys | `#FFFFFF` / `#B0B0B8` | Body text on dark surfaces |

**Brand migrations that came with the rename:**

| Old (ChaosStrap era) | New (NovaStrap era) |
|---|---|
| Badge maroon `#9B2335` | `#F30E1A` |
| App accent "Chaos Crimson" `#E51D35` | "Nova Red" `#F30E1A` |
| Tagline "Chaos, fully controlled." | "Chaos, in orbit." |

Accessibility note: `#F30E1A` on Graphite `#0C0C10` has strong contrast for UI accents; for long-form body text always use white/graphite greys, not the accent red.

## The emblem

The official mark is the **orbital emblem**: a dark glossy square (the client) with a black window cut-out, wrapped by a glowing crimson orbital ring, on void black.

**Rules:**

- **Clearspace:** keep free space of at least 25% of the emblem's width on every side. Nothing overlaps the ring — the ring is the identity.
- **Minimum size:** 24 × 24 px. Below that, use the `.ico` small frames instead of the full emblem.
- **Backgrounds:** dark surfaces (Void Black, Graphite) are the home turf. On light backgrounds it still works — the emblem carries its own dark mass — but never on busy or saturated backgrounds.
- **Don'ts:** don't recolor outside the two brand reds, don't stretch or skew, don't add outer glow or drop shadows (the glow is already in the art), don't rotate (it is already tilted on purpose), don't crop the ring, don't rearrange the composition.

## Assets

| File | Purpose |
|---|---|
| `brand/novastrap-emblem.png` | Official mark source — 1254 × 1254, transparent background |
| `brand/novastrap-mark.ico` | Multi-resolution icon generated from the source (256 / 128 / 64 / 48 / 32 / 16 px) |
| `Assets/novastrap-mark.png` | Repository copy of the mark (README hero, social preview) |
| `Assets/novastrap-mark.ico` | Application + installer icon |

If the mark ever changes, regenerate the `.ico` from the source PNG and update every surface listed in `RENAME_CHECKLIST.md` step 9.
