namespace Command_Design_Pattern
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Product product = new Product();
      ICommand command = new RedoCommand(product);
      Invoker invoker = new Invoker(command);
      invoker.ExecuteCommand();
    }
  }

  public interface ICommand
  {
    void Do();
  }

  public class RedoCommand : ICommand
  {
    private Product Product;
    public RedoCommand(Product product) { this.Product = product; }
    public void Do() { Product.Redo(); }
  }

  public class UndoCommand : ICommand
  {
    private Product Product;
    public UndoCommand(Product product) { this.Product = product; }
    public void Do() { Product.Undo(); }
  }

  public class Product
  {
    public void Redo()
    {
      Console.WriteLine("Redo done!");
    }

    public void Undo()
    {
      Console.WriteLine("Undo done!");
    }
  }

  public class Invoker
  {
    private ICommand command;
    public Invoker(ICommand command)
    {
      this.command = command;
    }

    public void ExecuteCommand()
    {
      command.Do();
    }
  }
}