﻿// =======================================================================================
// BarTemplate
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using wovencode;

namespace wovencode {
	
	// ===================================================================================
	// BarTemplate
	// ===================================================================================
	[CreateAssetMenu(fileName = "New BarTemplate", menuName = "Templates/New BarTemplate", order = 999)]
	public partial class BarTemplate : ScriptableTemplate
	{
    
    	/*
    	
    		Add your custom properties here, like:
    		
    		public int level;
    		public Sprite icon;
    		public string description;
    	
    	*/
    	
    	// performance improvement:
    	// Resources.LoadAll on a specific folder is much faster than on the whole Resources folder
		public static string _folderName = "";
		
		static Dictionary<int, BarTemplate> _data;
		
		// -------------------------------------------------------------------------------
        // data
        // loads the dictionary the first time it is accessed
        // skips if there are any duplicates and notifies the user
        // returns the cached dictionary
        // -------------------------------------------------------------------------------
		public static Dictionary<int, BarTemplate> data
		{
			get {
			
				BarTemplate.BuildCache();
			
				return _data;
			}
		}
		
		// -------------------------------------------------------------------------------
        // BuildCache
        // called when the dictionary is accessed the first time in order to build it
        // BuildCache can be called manually as well to load the dictionary
        // -------------------------------------------------------------------------------
		public static void BuildCache()
		{
			if (_data != null) return;
				
			List<BarTemplate> templates = Resources.LoadAll<BarTemplate>(BarTemplate._folderName).ToList();
					
			if (templates.HasDuplicates())
				Debug.LogWarning("[Warning] Skipped loading due to duplicate(s) in Resources subfolder: " + BarTemplate._folderName);
			else
				_data = templates.ToDictionary(x => x.hash, x => x);
			
		}
		
		// -------------------------------------------------------------------------------
        // OnEnable
        // We have to cache the folder name here (and not on the base class),
        // otherwise it would be the same for all objects
        // -------------------------------------------------------------------------------
		public void OnEnable()
		{
			if (_folderName != folderName)
				_folderName = folderName;
		}
		
		// -------------------------------------------------------------------------------
        // OnValidate
        // You can add custom validation checks here
        // -------------------------------------------------------------------------------
		public override void OnValidate()
		{
			
			base.OnValidate(); // always call base OnValidate as well!
			
			/*
				Example validation check:
				
				level = Mathf.Max(1, level);
			*/
			
		}
		
		// -------------------------------------------------------------------------------
        
	}

}

// =======================================================================================