   M S B A M L   `   `   `  ���� I  EBarApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BarApplication.Views.SellVBarApplication.Views.SellV  7    1BarApplication.Views.SellV.SellerOrderDetailsView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:BarApplication.Views.SellV     $
��1080��$	��520��  N� Title$  SellerOrderDetailsView�� � 	Resources  �� MergedDictionaries �� Source��  �� $$ ../Resources/ButtonStyles.xaml?��� $# ../Resources/ButtonIcons.xaml?�%    .��� 
���   � � ColumnDefinitions �� $��5* ��� $��6* � � RowDefinitions �� $��2* ��� $��8* ��� $
��1.5* �.+�� $��2��.+���  �� Orientation$ Vertical=�.+��� $��ORDER DETAILS��   	WhiteText#��[  $��50(�$��Center=�$	��Top=��� $��SELLER��#��[  $��0,0,0,5q�$��26(�$��Center=�$	��Top=��� $%��../Resources/Images/AB_icon.png��$��Center=�$��Right=�$��90���� -    ��Name$ DropDownMenu��$��3�� K� ZIndex$ 1��$��55��$
��Left=�$y�Visible=�$��1q�
���   �._�� ���#ff9000$��3�� �� $��2* ��� $��2* ��� $��6* ��� $
��1.5* �.+��� -   $��OpenB��$��1��$y�Visible=�  MenuButtonStyle#��[   MenuIcon
	 � Tag#	 [ �� -   $��HideB��$��1��$y�Hidden=�#��[ #	 [ �� $��Seller
Order details��$��45,0,0,0q�$��26(�$
��Bold"�$
��Left=�$��Center=��� $��ORDERS��$��1�� " MenuInterfaceButtonStyleSeller#��[   	OrderIcon#	 [ ���� *
GoToOrders+�� $
��AUTH��$��3��#��[   AuthorizationSellIcon#	 [ ���� *GoToAuthorization+� $��1��$��2��$��65,0,0,0q�
������� �� $��2* ��� $��3* �.+�� $��0�� �� $��2* ��� $��3* � �� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $��2* �.+��� $��Ordered table:��$��1��$��20(�$��Right=�$��Center=��� $��Product:��$��20(�$��2��$��Right=�$��Center=��� $��	Quantity:��$��20(�$��3��$��Right=�$��Center=��� $��50��$��30��$��Center=�$��1��$��1��$
��Left=�$��Center=����� *OpenedOrders+
 �� SelectedItem
 �� *SelectedOrder+���� .R��� ���� *Table.Number+��  �� DisplayMemberPath$
 Name��$	��200��$��30��$��Center=�$��2��$��1��$
��Left=�$��Center=����� *
Products+
 �� *SelectedProduct+�� $��3��$��1��$��20��$��50��$
��Left=�$��Center=����� *
Quantity+�� $��3��$��1��$��Center=�$��Center=����� *SelectedProductQuantity+� $��4��$��2�� �� $��1* ��� $��1* �.+���   RoundedCornerButtonStyle#��[ $	��ADD��$��20(�$��Center=�$��Center=�$��35��$	��100��
���������� *AddOrderDetail+�� #��[ $��DELETE��$��20(�$��Center=�$��Center=�$��1��$��35��$	��100��
���  ������ *DeleteOrderDetail+� $��1��$��2��.+�&   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��$��1��$��1�����#1A1A1A   CanUserAddRows$ False��   CanUserDeleteRows$ False��   
IsReadOnly$
 True��$��10q����� *OrderDetails+
 �� *SelectedOrderDetail+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Product��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Product.Name+  $ Quantity��$ *  �� *
Quantity+