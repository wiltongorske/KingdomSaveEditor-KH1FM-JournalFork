![Kingdom Save Editor](docs/banner.png)

---

## Fork note: KH1 Final Mix Journal support

This repository is a GPLv3 fork of Xeeynamo's archived [`KingdomSaveEditor`](https://github.com/Xeeynamo/KingdomSaveEditor). The main reason for this fork is a small but important KH1 Final Mix improvement for specific patches: support for editing the hidden Final Mix-only Journal flags tied to Ansem Reports 11 through 13, with `Ansem's Report 11` being the known practical fix.

This matters for players using the Japanese PS2 release of **Kingdom Hearts Final Mix** with an **English fan-translation patch**. That patch is known to miss a few Final Mix reward grants in actual gameplay. If you already progressed past those reward points on your memory card, switching to a fixed ISO later will not retroactively repair the save you already made. Similarly, you may not have access to a fixed ISO or to a Windows environment for applying the distributed patch. In practice, the known affected rewards are:

- `Encounter Plus`, which should be awarded after synthesizing 15 unique items from synthesis Groups 1 through 3
- `Zantetsuken`, which should be awarded after defeating Kurt Zisa in Agrabah
- `Ansem's Report 11`, which should also be awarded after defeating Kurt Zisa in Agrabah

The first two are ordinary ability edits and were already easy to repair through the save model. The important difference in this fork is `Ansem's Report 11`: in KH1 Final Mix, making the report visible in Jiminy's Journal requires more than setting the inventory item count. The working fix for affected patched saves is to set inventory count for item `149` to `1` and also set the Final Mix-only report Journal field at save offset `0x19C1`, bits `3..5`, to `100`. This fork exposes that hidden Journal-side state directly in the editor. It keeps the full Final Mix-only report mapping for reports `11` through `13` because those bits appear to belong to one compact structure, but the known broken reward in actual patched-save use is `Ansem's Report 11`; reports `12` and `13` are included for completeness rather than because they are known to be bugged.

## Reference from the original project

The remaining sections below are adapted from the original upstream `KingdomSaveEditor` README and kept here for reference.

---

| Supported games                | Console         | Region |
|--------------------------------| ----------------|--------|
| Kingdom Hearts I               | PS2/PS3/PS4/PC  | All    |
| Kingdom Hearts Re: CoM         | PS2/PS4/PC      | All    |
| Kingdom Hearts II              | PS2/PS3/PS4/PC  | US/EU/FM |
| Kingdom Hearts: Birth By Sleep | PSP/PS3/PS4/PC  | FM     |
| Kingdom Hearts: Dream Drop Distance | 3DS/PC     | All    |
| Kingdom Hearts 0.2             | PS4             | All    |
| Kingdom Hearts III             | PS4 only        | All    |
| Final Fantasy VII Remake       | PS4/PC          | All    |
| Persona 5, Persona 5 Royal     | PS3/PS4         | US/EU  |

[![Download](https://img.shields.io/github/downloads/xeeynamo/kh3saveeditor/total.svg?)](https://github.com/Xeeynamo/KH3SaveEditor/releases)*
![Last commit](https://img.shields.io/github/last-commit/xeeynamo/kh3saveeditor.svg)
![Tests status](https://github.com/xeeynamo/kh3saveeditor/workflows/Tests/badge.svg)

<sub><sup>*download count does not include downloads from the Microsoft Store.</sup></sub>

## Donations

Xeeynamo, the original creator of `KingdomSaveEditor`, is open to a [GitHub Sponsors program](https://github.com/sponsors/Xeeynamo). If the editor helped you and you would like to support the original project author, you can consider [donating to him](https://github.com/sponsors/Xeeynamo).

## User guide

You need to decrypt your save before opening it with Kingdom Save Editor. Please refer to [this guide](docs/decryption.md) to know how to decrypt your save.

## Special thanks

* Rikux3 for the incredible support of Kingdom Hearts 1 and Birth By Sleep Final Mix, the PC release of Kingdom Hearts games, the CBS PSU and PSV support
* Keytotruth for additional coding and offset findings for Kingdom Hearts III
* Delta-47 for the incredible support of Dream Drop Distance for 3DS, PS4 and PC and the European/Japanese support for Kingdom Hearts 1
* Skiller for the multiple offsets and values for Persona 5 / Royal and the tips for fix a Kingdom Hearts III checksum and decrypt the 1.5+2.5 ReMIX PC encrypted header
* Troopah to provide the icons used in the very first version of the editor
* Sonicshadowsilver2 for the early findings of story flags and records offsets for Kingdom Hearts III
* 13th Vessel to have found the complete story flags list for Kingdom Hearts III
* TALESIOFIFREAK for the ability list and DLC inventory for Kingdom Hearts III
* Silvercam for the list of gummiship inventory items for Kingdom Hearts III
* Luseu to have provided the majority of Final Fantasy VII Remake offsets
* All the sponsors / donators who contributed so far

## License

The code itself, the interface and the codes inside it are protected by GPL 3.0 license, unless specified differently in the root of a specific folder. In short, that means that for every change you made or code that you take from here, you need to make it open source somewhere, adding the original copyright statement and specify where the original code has been taken.

If you have more doubts about the GPL license, have a read to the following links:

[LICENSE info](https://tldrlegal.com/license/gnu-general-public-license-v3-(gpl-3))

[LICENSE Wikipedia](https://simple.wikipedia.org/wiki/GNU_General_Public_License)

## Privacy

The application will have full access to the file you will open by using "File\Open" in order to be able to modify your save game data and it will send the version of the save editor to provide customized messages at the home page to suggest what changes you will find in an eventual new version of this tool.

Few information such as name of the operating system, name of the game you choose to access to and crash reports will be send for diagnostic purpose and to improve the save editing functionalities. By knowing which games are modified the most, I can take knowledge of it and target them to add new editing features. You can also choose to send those reports anonymously. When not anonymous, a cookie will be send which represents a totally random number generated the very first time you open the Save Editor. The code is open source and there is absolute transparency on [which information are sent](KHSave.SaveEditor/Services/ReporterService.cs).
