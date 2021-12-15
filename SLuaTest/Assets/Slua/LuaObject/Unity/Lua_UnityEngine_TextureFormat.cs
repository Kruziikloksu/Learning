﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_TextureFormat : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.TextureFormat");
		addMember(l,1,"Alpha8");
		addMember(l,2,"ARGB4444");
		addMember(l,3,"RGB24");
		addMember(l,4,"RGBA32");
		addMember(l,5,"ARGB32");
		addMember(l,7,"RGB565");
		addMember(l,9,"R16");
		addMember(l,10,"DXT1");
		addMember(l,12,"DXT5");
		addMember(l,13,"RGBA4444");
		addMember(l,14,"BGRA32");
		addMember(l,15,"RHalf");
		addMember(l,16,"RGHalf");
		addMember(l,17,"RGBAHalf");
		addMember(l,18,"RFloat");
		addMember(l,19,"RGFloat");
		addMember(l,20,"RGBAFloat");
		addMember(l,21,"YUY2");
		addMember(l,22,"RGB9e5Float");
		addMember(l,24,"BC6H");
		addMember(l,25,"BC7");
		addMember(l,26,"BC4");
		addMember(l,27,"BC5");
		addMember(l,28,"DXT1Crunched");
		addMember(l,29,"DXT5Crunched");
		addMember(l,30,"PVRTC_RGB2");
		addMember(l,31,"PVRTC_RGBA2");
		addMember(l,32,"PVRTC_RGB4");
		addMember(l,33,"PVRTC_RGBA4");
		addMember(l,34,"ETC_RGB4");
		addMember(l,35,"ATC_RGB4");
		addMember(l,36,"ATC_RGBA8");
		addMember(l,41,"EAC_R");
		addMember(l,42,"EAC_R_SIGNED");
		addMember(l,43,"EAC_RG");
		addMember(l,44,"EAC_RG_SIGNED");
		addMember(l,45,"ETC2_RGB");
		addMember(l,46,"ETC2_RGBA1");
		addMember(l,47,"ETC2_RGBA8");
		addMember(l,48,"ASTC_RGB_4x4");
		addMember(l,49,"ASTC_RGB_5x5");
		addMember(l,50,"ASTC_RGB_6x6");
		addMember(l,51,"ASTC_RGB_8x8");
		addMember(l,52,"ASTC_RGB_10x10");
		addMember(l,53,"ASTC_RGB_12x12");
		addMember(l,54,"ASTC_RGBA_4x4");
		addMember(l,55,"ASTC_RGBA_5x5");
		addMember(l,56,"ASTC_RGBA_6x6");
		addMember(l,57,"ASTC_RGBA_8x8");
		addMember(l,58,"ASTC_RGBA_10x10");
		addMember(l,59,"ASTC_RGBA_12x12");
		addMember(l,60,"ETC_RGB4_3DS");
		addMember(l,61,"ETC_RGBA8_3DS");
		addMember(l,62,"RG16");
		addMember(l,63,"R8");
		addMember(l,64,"ETC_RGB4Crunched");
		addMember(l,65,"ETC2_RGBA8Crunched");
		addMember(l,-127,"PVRTC_4BPP_RGB");
		addMember(l,-127,"PVRTC_4BPP_RGBA");
		addMember(l,-127,"PVRTC_2BPP_RGB");
		addMember(l,-127,"PVRTC_2BPP_RGBA");
		LuaDLL.lua_pop(l, 1);
	}
}
