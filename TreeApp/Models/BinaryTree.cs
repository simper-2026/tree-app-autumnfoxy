public class BinaryTree{
  private Node? rootNode;
  public void Insert(int value){
    if(rootNode == null){
      rootNode = new Node(value, null);
    }else{
      Insert(value, rootNode);
    }
    UpdateHeight(rootNode);
  }
  private void Insert(int value, Node node){
    if(node.Value == value){
      return;
    }else if (value > node.Value){
      if (node.Right != null){
        Insert(value, node.Right);
      }else{
        node.Right = new Node(value, node);
      }
    }else{
      if (node.Left != null){
        Insert(value, node.Left);
      }else{
        node.Left = new Node(value, node);
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
    if (rootNode == null)
      return -1;
    return Height(rootNode);
  }
  private int Height(Node node){
    int result = 0;
    if (node.Left != null){
      result = 1 + Height(node.Left);
    }
    if (node.Right != null){
      result = Math.Max(result, 1+Height(node.Right));
    }
    return result;
  }
  public string ToMermaid(){
    int count = 0;
    if(rootNode == null){
      return "graph TD\n empty[\"(empty tree)\"]";
    }
    return "graph TD;\n" + $"{rootNode.Value}[{rootNode.Value} h:{rootNode.Height}]\n" + ToMermaid(rootNode, ref count);
  }
  private string ToMermaid(Node node, ref int count){
    string result = "";
    if(node.Left == null && node.Right == null){
      return "";
    }
    if(node.Left != null){
      result += $"{node.Value} --> {node.Left.Value}[{node.Left.Value} h:{node.Left.Height}]\n";
      count++;
      result += ToMermaid(node.Left, ref count);
    }else{
      result += $"{node.Value} --> _ph{count}[ ]\n";
      result += $"linkStyle {count} stroke:none,stroke-width:0,fill:none\n";
      result += $"style _ph{count} fill:none,stroke:none,color:none\n";
      count++;
    }
    if(node.Right != null){
      result += $"{node.Value} --> {node.Right.Value}[{node.Right.Value} h:{node.Right.Height}]\n";
      count++;
      result += ToMermaid(node.Right, ref count);
    }else{
      result += $"{node.Value} --> _ph{count}[ ]\n";
      result += $"linkStyle {count} stroke:none,stroke-width:0,fill:none\n";
      result += $"style _ph{count} fill:none,stroke:none,color:none\n";
      count++;
    }
    return result;
  }
  private int UpdateHeight(Node? node){
    if( node == null ){
      return -1;
    }
    int rHeight = UpdateHeight(node.Right);
    int lHeight = UpdateHeight(node.Left);
    int height = Math.Max(rHeight, lHeight) + 1;
    node.Height = height;
    return height;
  }
}
