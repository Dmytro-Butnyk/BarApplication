   M S B A M L   `   `   `  ���� I  EBarApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BarApplication.ViewsBarApplication.Views  &     BarApplication.Views.ManagerView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:BarApplication.Views     $
��1080��$	��520��  N� Title$  ManagerView�� � 	Resources  �� MergedDictionaries �� Source��  �� $$ ../Resources/ButtonStyles.xaml?��� $# ../Resources/ButtonIcons.xaml?�%    .��� ���#1A1A1A � ColumnDefinitions �� $��8* ��� $��3* � � RowDefinitions �� $��2* ��� $��8* ��� $
��1.5* �.+�� $��2��.+���  �� Orientation$ Vertical=�.+��� $��PRODUCTS��   	WhiteText#��[  $��50(�$��Center=�$	��Top=��� $��MANAGER��#��[  $��0,0,0,5q�$��26(�$��Center=�$	��Top=��� $%��../Resources/Images/AB_icon.png��$��Center=�$��Right=�$��90���� -    ��Name$ DropDownMenu��$��3�� K� ZIndex$ 1��$��55��$
��Left=�$y�Visible=�$��1q�
���   �._�� 
���  ��$��3�� �� $��2* ��� $��2* ��� $��2* ��� $��4* ��� $
��1.5* �.+��� -   $��OpenB��$��1��$y�Visible=�  MenuButtonStyle#��[   MenuIcon
	 � Tag#	 [ �� -   $��HideB��$��1��$y�Hidden=�#��[ #	 [ �� $��Manager
Products��$��45,0,0,0q�$��26(�$
��Bold"�$��Right=�$��Center=�$��0��$��0����   MenuInterfaceButtonStyle#��[   SuppliesIcon#	 [ $��1������ *GoToSuppliesCommand+.��
SUPPLIES�� #��[   	UsersIcon#	 [ $��2������ *GoToUsersCommand+.��USERS�� $
��AUTH��$��4��#��[   AuthorizationManIcon#	 [ ���� *GoToAuthorization+� $��1��$��2��
�������$��55,0,0,0q� �� $
��2.5* ��� $��* �.+�&   System.Windows.Controls.DataGrid  $��10q�$��0��$��1��
   	RowHeight$
 30Q�   AutoGenerateColumns$ False��   
IsReadOnly$
 True������ *
Products+ �� SelectedItem �� *SelectedProduct+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Product name��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ Price��$ *  �� *Price+  $ Quantity��$ *  �� *
Quantity+  $��10q�$��0��$��1��$
 30Q�$ False��$
 True������ *AlcoholDrinks+ �� *SelectedProduct+y��� *IsVisibleAlcoholDrinks+   $ 
Drink name��$ *  �� *Name+  $ Price��$ *  �� *Price+  $ Quantity��$ *  �� *
Quantity+  $	 ABV��$ *  �� *ABV+  $��10q�$��0��$��1��$
 30Q�$ False��$
 True������ *Snacks+ �� *SelectedProduct+y��� *IsVisibleSnacks+   $ 
Snack name��$ *  �� *Name+  $ Price��$ *  �� *Price+  $ Quantity��$ *  �� *
Quantity+  $
 Type��$ *  �� *Type+� $��2��$��2�� �� $��1* ��� $��1* �.+���   RoundedCornerButtonStyle#��[ $	��Add��$��0��$��18(�$��10,15q�
���������� *AddProductButton+y��� *IsVisibleAdditionPoles+�� #��[ $��Delete��$��1��$��18(�$��10,15q�
���  ������ *DeleteProductButton+�� #��[ $	��Add��$��0��$��18(�$��10, 15q�
���������� *AddTableCommand+y��� *IsVisibleNewTableFields+� $��0��$��2��$��55,10,10,10q�y��� *IsVisibleNewTableFields+.+��� #��[  $��Table quantity:��$	��Top=�$
��Left=��� $��25��$	��100��$��0,10,0,0q�$��Center=�$��Center=����� *NewTableNumber+�� #��[ $��Delete all tables��$��1��$��Right=�$��10,10q�
���  ������ *DeleteTablesCommand+� $��0��$��2��$��55,10,10,10q�y��� *IsVisibleAdditionPoles+ �� $��1* ��� $��1* ��� $��1* �.+��� #��[  $��Product name:��$	��Top=�$
��Left=��� $��25��$	��100��$��0,10,0,0q�$��Center=�$��Center=����� *ProductName+�� #��[  $��Product price:��$��1��$	��Top=�$
��Left=��� $��25��$	��100��$��0,10,0,0q�$��1��$��Center=�$��Center=����� *ProductPrice+�� #��[  $��2��$	��Top=�$
��Left=����� *LabelProductType+�� $��25��$	��100��$��0,10,0,0q�$��2��$��Center=�$��Center=����� *ProductSpecialization+� $��2��$��1�����#1A1A1A$��10q� �� $��1* ��� $��1* ��� $��1* ��� $��2* ��� $��1* ��� $��1* ��� $��1* �.+��� #��[ 
�������$��10, 3q�$��18(�$��SHOW ALL��$��0������ *ShowProductsButton+�� #��[ 
�������$��18(�$��10, 3q�$��SHOW DRINKS��$��1������ *ShowAlcoholDrinksButton+�� #��[ 
�������$��18(�$��10, 3q�$��SHOW SNACKS��$��2������ *ShowSnacksButton+�� #��[ $��18(�$��10, 3q�$��	ADD DRINK��$��4������ *AddDrinkButton+�� #��[ $��10, 3q�$��18(�$��	ADD SNACK��$��5������ *AddSnackButton+�� #��[ $��18(�$��10, 3q�$��	ADD TABLE��$��6������ *ShowTableFields+