public class BinaryTree{
  private Node? rootNode;
  public void Insert(int value){
    if(rootNode == null){
      rootNode = new Node(value, null);
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
        node.Right = new Node(value, node);
        UpdateHeight(rootNode);
        Rebalance(node.Right);
      }
    }else{
      if (node.Left != null){
        Insert(value, node.Left);
      }else{
        node.Left = new Node(value, node);
        UpdateHeight(rootNode);
        Rebalance(node.Left);
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
    if(node.Right != null){
      node.Right.Parent = node;
    }
    if(node.Left != null){
      node.Left.Parent = node;
    }
    return height;
  }
  private Node RotateRight(Node z){
    Node y = z.Left;
    Node? t3 = y.Right;
    y.Right = z;
    z.Left = t3;
    return y;
  }
  private Node RotateLeft(Node z){
    Node y = z.Right;
    Node? t2 = y.Left;
    y.Left = z;
    z.Right = t2;
    return y;
  }
  private void Rebalance(Node node){
    int diff = (node.Left?.Height ?? -1) - (node.Right?.Height ?? -1);
    if(diff > 1){
      if(node.Parent == null){
        rootNode = RotateRight(node);
        rootNode.Parent = null;
      }else if(node.Parent.Right == node){
        node.Parent.Right = RotateRight(node);
      }else if (node.Parent.Left == node){
          node.Parent.Left = RotateRight(node);
      }
      UpdateHeight(rootNode);
    }
    if(diff < -1){
      if(node.Parent == null){
        rootNode = RotateLeft(node);
        rootNode.Parent = null;
      }else if(node.Parent.Right == node){
        node.Parent.Right = RotateLeft(node);
      }else if (node.Parent.Left == node){
          node.Parent.Left = RotateLeft(node);
      }
      UpdateHeight(rootNode);
    }
    if(node.Parent != null){
      Rebalance(node.Parent);
    }
  }
}
