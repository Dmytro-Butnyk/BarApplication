   M S B A M L   `   `   `  ���� I  EBarApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BarApplication.ViewsBarApplication.Views  .    (BarApplication.Views.ManagerSuppliesView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:BarApplication.Views     $
��1080��$	��520��  N� Title$  ManagerSuppliesView�� � 	Resources  �� MergedDictionaries �� Source��  �� $$ ../Resources/ButtonStyles.xaml?��� $# ../Resources/ButtonIcons.xaml?�%    .��� ���#1A1A1A � ColumnDefinitions �� $��5* ��� $��6* � � RowDefinitions �� $��2* ��� $��8* ��� $
��1.5* �.+�� $��2��.+���  �� Orientation$ Vertical=�.+��� $��SUPPLIES��   	WhiteText#��[  $��50(�$��Center=�$	��Top=��� $��MANAGER��#��[  $��0,0,0,5q�$��26(�$��Center=�$	��Top=��� $%��../Resources/Images/AB_icon.png��$��Center=�$��Right=�$��90���� -    ��Name$ DropDownMenu��$��3�� K� ZIndex$ 2��$��55��$
��Left=�$y�Visible=�$��1q�
���   �._�� 
���  ��$��3�� �� $��2* ��� $��2* ��� $��2* ��� $��4* ��� $
��1.5* �.+��� -   $��OpenB��$��1��$y�Visible=�  MenuButtonStyle#��[   MenuIcon
	 � Tag#	 [ �� -   $��HideB��$��1��$y�Hidden=�#��[ #	 [ �� $��Manager
Supplies��$��	45, 0,0,0q�$��26(�$
��Bold"�$��Right=�$��Center=�$��0���� $��PRODUCTS��$��1��  MenuInterfaceButtonStyle#��[   ProductsIcon#	 [ ���� *GoToProductsCommand+�� $��USERS��$��2��#��[   	UsersIcon#	 [ ���� *GoToUsersCommand+�� $
��AUTH��$��4��#��[   AuthorizationManIcon#	 [ ���� *GoToAuthorization+� $ 1�����#1A1A1A$��65,10,10,10q�$��0��$��1�� �� $
��1.5* ��� $��2* ��� $��2* ��� $��2* ��� $��2* �.+��� $��Supply information��#��[  $��26(�$��Center=�$	��Top=��� $��Product:��#��[  $��16(�$��1��$
��20,0q�$
��Left=�$��Center=��� 
 �� DisplayMemberPath$

 Name��$��1��$	��200��$��30��$��30, 0q�$��Right=����� *
Products+ �� SelectedItem �� *SelectedProduct+�� $��	Quantity:��#��[  $��16(�$��2��$
��20,0q�$
��Left=�$��Center=��� $	��200��$��2��$��30��$��30, 0q�$��Right=����� *
Quantity+�� $��Supply time:��#��[  $��16(�$��3��$
��20,0q�$
��Left=�$��Center=��� #��[  $��20(�$��3��$
��30,0q�$��Right=�$��Center=����� *
SupplyDate+�� $��
ADD SUPPLY��$��4��$��60, 20q�
���������� *AddSupplyCommand+� 
�������$��2��$��1�� �� $��1* ��� $
��1.2* �.+�&   System.Windows.Controls.DataGrid  $��1��$��1��
������    AutoGenerateColumns$ False��   
IsReadOnly$
 True������ *
Supplies+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Product name��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Product.Name+  $ Quantity��$ *  �� *
Quantity+  $ Supply time��$ *  �� *
SupplyTime+