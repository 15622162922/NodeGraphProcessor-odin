using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GraphProcessor;
using System.Linq;

namespace NodeGraphProcessor.Examples
{
    [System.Serializable, NodeMenuItem("Story/UI/Image")]
    public class ImageNode : BaseNode
    {
        [Input(name = "Executed", allowMultiple = true)]
        public ConditionalLink	executed;
        public override string		name => "Image";
        public Sprite sprite;
        protected override void Process()
        {

        }
    }
}
