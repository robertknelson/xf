// <copyright company="eXtensoft, LLC" file="Message_2.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using XF.Common.Wcf;

    public class Message<T, U> : Message<T>, IResponse<T, U> where T : class, new()
    {

        public U ActionResult { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public Message(IContext context, ModelActionOption modelActionOption)
        : base(context, modelActionOption)
        { }

        public Message(IEnumerable<TypedItem> items)
        : base(items)
        { }

        public override void Assimilate(DataPacket item)
        {
            item.Items.Clear();
            item.Items = this.Items;
            item.Buffer = GenericSerializer.Serialize(ActionResult);
        }

        public void InsertContentList(object o)
        {
            IEnumerable<T> list = o as IEnumerable<T>;
            if (list != null)
            {
                foreach (var item in list)
                {
                    Content.Add(item);
                }
            }

            //foreach (object o in list)
            //{
            //    if (o is T)
            //    {
            //        Content.Add(o as T);
            //    }                
            //}

        }
    }
}

