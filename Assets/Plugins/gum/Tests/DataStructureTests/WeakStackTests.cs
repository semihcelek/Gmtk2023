﻿using Gum.Core.DataStructures;
using NUnit.Framework;

namespace Tests.DataStructureTests
{
    [TestFixture]
    public class WeakStackTests
    {
        [Test]
        public void Push()
        {
            WeakStack<Foo> weakStack = new WeakStack<Foo>();

            for (int count = 0; count < 100; count++)
            {
                weakStack.Push(new Foo());
            }
            
            Assert.AreEqual(weakStack.Count, 100);
        }

        [Test]
        public void Pop()
        {
            WeakStack<Foo> weakStack = new WeakStack<Foo>();
            
            weakStack.Push(new Foo());
            
            Foo poppedObject = weakStack.Pop();
            
            Assert.NotNull(poppedObject);
        }
    }
}