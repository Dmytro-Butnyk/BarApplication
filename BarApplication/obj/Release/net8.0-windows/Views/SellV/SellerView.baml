   M S B A M L   `   `   `  ���� I  EBarApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BarApplication.ViewsBarApplication.Views  %    BarApplication.Views.SellerView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:BarApplication.Views     $
��1080��$	��520��  N� Title$  
SellerView�� � 	Resources  �� MergedDictionaries �� Source��  �� $$ ../Resources/ButtonStyles.xaml?��� $# ../Resources/ButtonIcons.xaml?�%    .��� 
���   � � ColumnDefinitions �� $��5* ��� $��6* � � RowDefinitions �� $��2* ��� $��8* ��� $
��1.5* �.+�� $��2��.+���  �� Orientation$ Vertical=�.+��� $��ORDERS��   	WhiteText#��[  $��50(�$��Center=�$	��Top=��� $��SELLER��#��[  $��0,0,0,5q�$��26(�$��Center=�$	��Top=��� $%��../Resources/Images/AB_icon.png��$��Center=�$��Right=�$��90���� -    ��Name$ DropDownMenu��$��3�� K� ZIndex$ 1��$��55��$
��Left=�$y�Visible=�$��1q�
���   �._�� ���#ff9000$��3�� �� $��2* ��� $��2* ��� $��6* ��� $
��1.5* �.+��� -   $��OpenB��$��1��$y�Visible=�  MenuButtonStyle#��[   MenuIcon
	 � Tag#	 [ �� -   $��HideB��$��1��$y�Hidden=�#��[ #	 [ �� $��Seller
Orders��$��26(�$
��Bold"�$��45,0,0,0q�$��Right=�$��Center=��� $��DETAILS��$��Center=�$��1�� " MenuInterfaceButtonStyleSeller#��[   OrderDetailsIcon#	 [ ���� *GoToOrderDetails+�� $
��AUTH��$��3��#��[   AuthorizationSellIcon#	 [ ���� *GoToAuthorization+� 
�������$��2��$��1��$��65,0,0,0q� �� $��2* ��� $��3* �.+��  �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��Table Number:��$��1��$��Center=�$��18(��� 
 �� DisplayMemberPath$
 Number��$��1��$��0��$��Center=�$	��150������ *Tables+ �� SelectedItem �� *SelectedTable+�� $��Order Date:��$��2��$��Center=�$��18(��� $��2��$��0��$	��150��$��Center=����� *	OrderDate+��   RoundedCornerButtonStyle#��[ 
������$��	Add Order��$��20(�$	��150��$��3��$
��0,10q�$��Center=����� *AddOrderCommand+� $��2��$��1��$��10q����#1A1A1A �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��Orders��$��20(�$
��Bold"�#��[  &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��$��1��   	RowHeight$ 30Q�$��1��
������    
IsReadOnly$
 True������ *Orders+ �� *SelectedOrder+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Table��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Table.Number+  $ 
Order Time��$ *  �� *Date+�� $��2��$ 
Horizontal=�$
��0,10q�.+��� $��Opened��$��0,0,10,0q�
����������� *ShowOpenedCommand+���� *IsOpenedButtonSelected+�� $��Closed��$��0,0,10,0q�
����������� *ShowClosedCommand+���� *IsClosedButtonSelected+�� #��[ $��Close Order ��$��50,0,0,0q�$	��100������ *CloseOrderCommand+�� ${�False��$��Order Status��
�������$��Center=�$
��30,0q�$��3��$��2�� d� 	IsChecked �� *SelectedOrder.IsOpened+