using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class CoContravariance
    {
        static void Main(string[] args)
        {
            BoxofBalls boxofBalls = new BoxofBalls();// Good
            BoxOfPens boxOfPens = new BoxOfPens();// Good
                                                  // IContainer<Item> boxOfBalls = new BoxofBalls(); // Not good as IContainer<Item> can add pens to BoxofBalls
            ModifiedBoxOfBalls modifiedBoxOfBalls = new ModifiedBoxOfBalls();
            modifiedBoxOfBalls.add(new Ball());

            ICovariantContainer<Item> boxofModifiedBalls = new ModifiedBoxOfBalls(); // This is fine as you can only remove items but but not adding anything 
                                                                                     // there by keeping typesafety
            boxofModifiedBalls.remove(0);

            IContraVariantContainer<Item> items = new BoxOfItems();// Technically this is fine as the add method still takes base Item as input 
                                                                   // and lets to add any derived type of item 
            items.add(new Ball());
            items.add(new Pen());

            
        }
    }

    public interface Item
    {
        int Id { get; set; }
    }

    /// <summary>
    /// Generic Container of items
    /// </summary>
    /// <typeparam name="T">Type of Item</typeparam>
    public interface IContainer<T> where T : Item
    {
        T[] Items { get; set; }
        void add(T item);
        T remove(int index);
    }

    /// <summary>
    /// Base Container
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseContainer<T> where T : Item
    {
        T[] item { get; set; }
    }

    /// <summary>
    /// Covariant interface. It doesn't allow adding new Items there by enforcing type safety
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICovariantContainer<out T> where T: Item
    {
        T remove(int index);
    }

    /// <summary>
    /// Contravariant interface allowing to add base item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContraVariantContainer<in T> where T : Item
    {
        void add(T item);
    }

    public class Ball : Item
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class Pen : Item
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class Bottle : Item
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


  
    public class BoxOfPens : IContainer<Pen>
    {
        public Pen[] Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void add(Pen item)
        {
            throw new NotImplementedException();
        }

        public Pen remove(int index)
        {
            throw new NotImplementedException();
        }
    }

    public class BoxofBalls : IContainer<Ball>
    {
        public Ball[] Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void add(Ball item)
        {
            throw new NotImplementedException();
        }

        public Ball remove(int index)
        {
            throw new NotImplementedException();
        }
    }

    public class ModifiedBoxOfBalls : IBaseContainer<Ball>, ICovariantContainer<Ball>, IContraVariantContainer<Ball>
    {
        public Ball[] item { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void add(Ball item)
        {
            throw new NotImplementedException();
        }

        public Ball remove(int index)
        {
            throw new NotImplementedException();
        }
    }


    public class BoxOfItems : IBaseContainer<Item>, ICovariantContainer<Item>, IContraVariantContainer<Item>
    {
        public Item[] item { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void add(Item item)
        {
            throw new NotImplementedException();
        }

        public Item remove(int index)
        {
            throw new NotImplementedException();
        }
    }
}
