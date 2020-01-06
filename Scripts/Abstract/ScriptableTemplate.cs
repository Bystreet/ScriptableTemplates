﻿// =======================================================================================
// ScriptableTemplate
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using System;
using UnityEngine;
using wovencode;

namespace wovencode {
	
	// ===================================================================================
	// ScriptableTemplate
	// ===================================================================================
	public abstract partial class ScriptableTemplate : ScriptableObject
	{
		
		[Header("Basic Info")]
		[Tooltip("This name will be displayed to the end-user (copied from object name if empty)")]
		public string 			title;				// we never use the object name as the name that is shown to users
													// instead we provide a custom string property called 'title'
													// this way, you can rename your objects anytime without messing up
													// the dictionary (as the dictionary keys are generated using the
													// true name of the object)
													
		[Tooltip("The name of a subfolder in the project 'Resources' folder (case-sensitive)")]
    	public string 			folderName;
		
		protected string 		_name; 				// we cache the object name here for a bit of performance
		
		// -------------------------------------------------------------------------------
        // name
        // instead of returning the objects name each time it is accessed, we cache it in
        // a local variable and return that one (less allocations)
        // -------------------------------------------------------------------------------
		public new string name
		{
			get {
				if (string.IsNullOrWhiteSpace(_name))
					_name = base.name;
				return _name;
			}
		}
		
		// -------------------------------------------------------------------------------
        // OnValidate
        // if the title is empty, we simple copy the object name into the title
        // note that we cannot cache the folderName here, because it would the same for all objects of this type
        // -------------------------------------------------------------------------------
		public virtual void OnValidate()
		{
	
			if (String.IsNullOrWhiteSpace(title))
				title = name;
			
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================