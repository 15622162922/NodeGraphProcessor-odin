﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using GraphProcessor;

[NodeCustomEditor(typeof(IfNode))]
public class IfNodeView : BaseNodeView
{
	public override void Enable()
	{
		hasSettings = true;	// or base.Enable();
		var node = nodeTarget as IfNode;
		Label label = new Label( $"Last Evaluation: {node.condition}");
		node.onProcessed += ()=>
		{
			label.text = $"Last Evaluation: {node.condition}";
		};
		// Create your fields using node's variables and add them to the controlsContainer
		controlsContainer.Add(label);
	}
}