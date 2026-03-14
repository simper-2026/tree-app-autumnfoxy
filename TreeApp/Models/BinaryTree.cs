public class BinaryTree{
  private Node? rootNode;
  public void Insert(int value){
    if(rootNode == null){
      rootNode = new Node(value);
    }else{
      Insert(value, rootNode);
    }
  }
  private void Insert(int value, Node node){
    if(node.Value == value){
      return;
    }else if (value > node.Value){
      if (node.Right != null){
        Insert(value, node.Right);
      }else{
        node.Right = new Node(value);
      }
    }else{
      if (node.Left != null){
        Insert(value, node.Left);
      }else{
        node.Left = new Node(value);
      }
    }
  }

  public string InOrder(){
    if (rootNode == null)
      return "";
    return InOrder(rootNode);
  }
  
  private string InOrder(Node node){
    string result = "";
    if (node.Left != null){
      result += InOrder(node.Left);
    }
    result += node.Value + " ";
    if (node.Right != null){
      result += InOrder(node.Right);
    }
    return result;
  }
  
  public int Height(){
    return -1;
  }
  public string ToMermaid(){
    return "";
  }
}
