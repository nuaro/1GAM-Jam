<?xml version="1.0" encoding="UTF-8"?>
<tileset name="dirtwall" tilewidth="32" tileheight="32" tilecount="18" columns="9">
 <image source="Textures/World Sprites/s_dirtwall_tileset.png" trans="000000" width="288" height="64"/>
 <terraintypes>
  <terrain name="New Terrain" tile="2"/>
 </terraintypes>
 <tile id="1">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="32" height="32"/>
  </objectgroup>
 </tile>
 <tile id="2" terrain=",0,0,0">
  <objectgroup draworder="index">
   <object id="2" x="26" y="0" width="6" height="32"/>
   <object id="4" x="0" y="16" width="32" height="16"/>
  </objectgroup>
 </tile>
 <tile id="3" terrain="0,,0,0">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="6" height="32"/>
   <object id="2" x="0" y="16" width="32" height="16"/>
  </objectgroup>
 </tile>
 <tile id="4" terrain=",,0,0">
  <objectgroup draworder="index">
   <object id="1" x="0" y="16" width="32" height="16"/>
  </objectgroup>
 </tile>
 <tile id="5" terrain="0,0,,0">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="32" height="6"/>
   <object id="2" x="26" y="0" width="6" height="32"/>
  </objectgroup>
 </tile>
 <tile id="6" terrain=",0,,0">
  <objectgroup draworder="index">
   <object id="1" x="26" y="0" width="6" height="32"/>
  </objectgroup>
 </tile>
 <tile id="7" terrain="0,,,0">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="6" height="6"/>
   <object id="2" x="26" y="17" width="6" height="15"/>
  </objectgroup>
 </tile>
 <tile id="8" terrain=",,,0">
  <objectgroup draworder="index">
   <object id="1" x="26" y="17" width="6" height="15"/>
  </objectgroup>
 </tile>
 <tile id="10" terrain="0,0,0,">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="32" height="6"/>
   <object id="2" x="0" y="6" width="6" height="26"/>
  </objectgroup>
 </tile>
 <tile id="11" terrain=",0,0,">
  <objectgroup draworder="index">
   <object id="1" x="16" y="0" width="16" height="16"/>
   <object id="2" x="0" y="16" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="12" terrain="0,,0,">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="6" height="32"/>
  </objectgroup>
 </tile>
 <tile id="13" terrain=",,0,">
  <objectgroup draworder="index">
   <object id="1" x="0" y="16" width="6" height="16"/>
  </objectgroup>
 </tile>
 <tile id="14" terrain="0,0,,">
  <objectgroup draworder="index">
   <object id="1" x="-1" y="-0.333333" width="33.3333" height="6"/>
  </objectgroup>
 </tile>
 <tile id="15" terrain=",0,,"/>
 <tile id="16" terrain="0,,,"/>
 <tile id="17" terrain="0,0,0,0">
  <objectgroup draworder="index"/>
 </tile>
</tileset>
