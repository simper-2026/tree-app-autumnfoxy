public class Node{
  public Node(int value, Node? parent, Node? left=null, Node? right=null){
    Height = 0;
    Value = value;
    Left = left;
    Right = right;
    Parent = parent;
  }
  public int Height{ get; set; }
  public int Value{ get; private set; }
  public Node? Left{ get; set; }
  public Node? Right{ get; set; }
  public Node? Parent{ get; set; }
}
