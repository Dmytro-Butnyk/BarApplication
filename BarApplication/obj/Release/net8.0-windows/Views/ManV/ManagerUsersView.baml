   M S B A M L   `   `   `  ���� I  EBarApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BarApplication.ViewsBarApplication.Views  +    %BarApplication.Views.ManagerUsersView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:BarApplication.Views     $
��1080��$	��520��  N� Title$  ManagerUsersView�� � 	Resources  �� MergedDictionaries �� Source��  �� $$ ../Resources/ButtonStyles.xaml?��� $# ../Resources/ButtonIcons.xaml?��� $* $../Resources/PlaceholderTextBox.xaml?�%    .��� ���#1A1A1A � ColumnDefinitions �� $
��7.5* ��� $
��4.5* � � RowDefinitions �� $��2* ��� $��8* ��� $
��1.5* �.+��� -    ��Name$ DropDownMenu��$��3�� K� ZIndex$ 1��$��55��$
��Left=�$y�Visible=�$��1q�
���   �._�� 
���  ��$��3�� �� $��2* ��� $��2* ��� $��2* ��� $��4* ��� $
��1.5* �.+��� -   $��OpenB��$��1��$y�Visible=�   MenuButtonStyle#��[    MenuIcon
 � Tag# [ �� -   $��HideB��$��1��$y�Hidden=�#��[  # [ �� $��Manager
Users��$��45,0,0,0q�$��26(�$
��Bold"�$��Right=�$��Center=�$��0��$��0���� $��PRODUCTS��$��1��  MenuInterfaceButtonStyle#��[   ProductsIcon# [ ���� *GoToProductsCommand+�� #��[   SuppliesIcon# [ $��2������ *GoToSuppliesCommand+.��
SUPPLIES�� $
��AUTH��$��4��#��[   AuthorizationManIcon# [ ���� *GoToAuthorization+� $��2��.+��� 	 �� Orientation$	 Vertical=�.+��� $��USERS��  	WhiteText#��[ $��50(�$��Center=�$	��Top=��� $��MANAGER��#��[ $��0,0,0,5q�$��26(�$��Center=�$	��Top=��� $%��../Resources/Images/AB_icon.png��$��Center=�$��Right=�$��90��� ���#FAFADD$��2��$��55, 0, 0, 0q�$��0��$��1�� �� $
��1.5* ��� $��1* � �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��User:��$��16(�$��0��$��150,0q�$
��Left=�$��Center=��� 
 �� DisplayMemberPath$
 Login��$��0��$	��200��$��30��$��150, 0q�$��Right=����� *Users+ �� SelectedItem �� *SelectedUser+ �� Mode$ TwoWay=��� $��Login��$��10,0,0,0q�$��2��$
��Left=�$	��Top=�y��� *AddFieldsVisibility+��   PlaceholderTextBox#��[ $ Login��$��2��$��	10,10,0,0q�$	��100��$��Center=�$
��Left=����� *NLogin+y��� *AddFieldsVisibility+�� $��Password��$��2��$��Center=�$	��Top=�y��� *AddFieldsVisibility+�� #��[ $ Password��$��2��$��	10,10,0,0q�$	��100��$��Center=�$��Center=����� *	NPassword+y��� *AddFieldsVisibility+�� $��Position��$��0,0,10,0q�$��2��$��Right=�$	��Top=�y��� *AddFieldsVisibility+�� $��2��$��	0,10,10,0q�$	��100��$��Center=�$��Right=����� *
NPositions+ �� *	NPosition+y��� *AddFieldsVisibility+�� $��1��$��ADD USER��$��30,0,0,0q�$
��Left=�$��Center=�$��15q����� *ShowAddFieldsCommand+�� $��1��$��DELETE USER��
���  ��$��	30,0,30,0q�$��Right=�$��Center=�$��15q����� *DeleteUserCommand+�� $	��ADD��$��25(�
������$��3��$	��150��$��Center=����� *AddUserCommand+y��� *AddFieldsVisibility+� $��1��$��1�����#1A1A1A$��10q� �� $
��1.5* ��� $��* ��� $��* ��� $��* ��� $
��1.5* �.+��� $��Detail information��#��[ $��26(�$��Center=�$	��Top=��� $��1��$	 
Horizontal=�$��Center=�.+��� $��Login:��$��18(�#��[ �� $��16(�#��[ ���� *Login+�� $��2��$	 
Horizontal=�$��Center=�.+��� $��	Password:��$��18(�#��[ �� $��16(�#��[ ���� *
Password+�� $��3��$	 
Horizontal=�$��Center=�.+��� $��	Position:��$��18(�#��[ �� $��16(�#��[ ���� *
Position+