﻿// =======================================================================================
// ExampleTemplate
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
	// ExampleTemplate
	// ===================================================================================
	public partial class ExampleTemplate : ScriptableTemplate
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
		
		static Dictionary<int, ExampleTemplate> _data;
		
		// -------------------------------------------------------------------------------
        // data
        // loads the dictionary the first time it is accessed
        // skips any duplicate (by object name) and notifies, but continues loading
        // returns the cached dictionary
        // -------------------------------------------------------------------------------
		public static Dictionary<int, ExampleTemplate> data
		{
			get {
			
				if (_data == null)
				{
			
					List<ExampleTemplate> templates = Resources.LoadAll<ExampleTemplate>(ExampleTemplate._folderName).ToList();
					
					if (templates.HasDuplicates())
						Debug.LogWarning("[Warning] Skipped loading due to duplicate(s) in Resources subfolder: " + ExampleTemplate._folderName);
					else
						_data = templates.ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
						
				}
			
				return _data;
			}
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