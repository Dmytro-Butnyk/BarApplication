   M S B A M L   `   `   `  ����I  EBarApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BarApplication.ViewsBarApplication.Views  5      .    (BarApplication.Views.ManagerSuppliesView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:BarApplication.Views     5      $
��1080��5      $	��520��5	        N� Title$  ManagerSuppliesView��5
       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $$ ../Resources/ButtonStyles.xaml?�6%   �� 5      $# ../Resources/ButtonIcons.xaml?�6%   %    5      .��5      � ���#1A1A1A � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��6* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��8* �6   �� 5      $
��1.5* �6   .+�5    
   � $��2��6   .+�5!      ��  �� Orientation$ Vertical=�6   .+�5"      �� $��SUPPLIES��6      	WhiteText#��[  5#      $��50(�5$      $��Center=�5%      $	��Top=�5&      �� 5'      $��MANAGER��6   #��[  5(      $��0,0,0,5q�5)      $��26(�5*      $��Center=�5+      $	��Top=�5,      5-      �� 5/      $%��../Resources/Images/AB_icon.png��6   $��Center=�50      $��Right=�51      $��90��52      53      �� 55   
   -   5         ��Name$ DropDownMenu��56      $��3��57       K� ZIndex$ 2��58      $��55��59      $
��Left=�5:      $y�Visible=�5;      $��1q�5<      
���   �._�5>      � 
���  ��$��3��5?       5@      �� 5A      $��2* �6$   �� 5B      $��2* �6$   �� 5C      $��2* �6$   �� 5D      $��4* �6$   �� 5E      $
��1.5* �6$   .+�5H      �� -   5        $��OpenB��5H      $��1��5J      $y�Visible=�5K        MenuButtonStyle#��[ 5L        MenuIcon
	 � Tag#	 [ 5M      �� 5O      -   5        $��HideB��5O      $��1��5Q      $y�Hidden=�5R      #��[ 5S      #	 [ 5T      �� 5V      $��Manager
Supplies��5W      $��	45, 0,0,0q�5X      $��26(�5Y      $
��Bold"�5Z      $��Right=�5[      $��Center=�5\      $��0��5]      �� 5^      $��PRODUCTS��5_      $��1��5a        MenuInterfaceButtonStyle#��[ 5b        ProductsIcon#	 [ 5c      ��5`      �� *GoToProductsCommand+5c      �� 5d      $��USERS��5e      $��2��5g      #��[ 5h        	UsersIcon#	 [ 5i      ��5f      �� *GoToUsersCommand+5i      �� 5k      $
��AUTH��5m      $��4��5n      #��[ 5o        AuthorizationManIcon#	 [ 5p      ��5l      �� *GoToAuthorization+5p      5q      5r      � 5u   
   $ 1��5v      ���#1A1A1A$��65,10,10,10q�5x      $��0��5y      $��1��5z       5|      �� 5}      $
��1.5* �6    �� 5~      $��2* �6    �� 5      $��2* �6    �� 5�      $��2* �6    �� 5�      $��2* �6    .+�5�      �� $��Supply information��5�      #��[  5�      $��26(�5�      $��Center=�5�      $	��Top=�5�      �� 5�      $��Product:��5�      #��[  5�      $��16(�5�      $��1��5�      $
��20,0q�5�      $
��Left=�5�      $��Center=�5�      �� 5�      
 �� DisplayMemberPath$

 Name��5�      $��1��5�      $	��200��5�      $��30��5�      $��30, 0q�5�      $��Right=�5�      ��5�      �� *
Products+ �� SelectedItem 5�      �� *SelectedProduct+5�      �� 5�      $��	Quantity:��5�      #��[  5�      $��16(�5�      $��2��5�      $
��20,0q�5�      $
��Left=�5�      $��Center=�5�      �� 5�      $	��200��5�      $��2��5�      $��30��5�      $��30, 0q�5�      $��Right=�5�      ��5�      �� *
Quantity+5�      �� 5�      $��Supply time:��5�      #��[  5�      $��16(�5�      $��3��5�      $
��20,0q�5�      $
��Left=�5�      $��Center=�5�      �� 5�      #��[  5�      $��20(�5�      $��3��5�      $
��30,0q�5�      $��Right=�5�      $��Center=�5�      ��5�      �� *
SupplyDate+5�      �� 5�      $��
ADD SUPPLY��5�      $��4��5�      $��60, 20q�5�      
��������5�      �� *AddSupplyCommand+5�      5�      � 5�   
   
�������$��2��5�      $��1��5�       5�      �� 5�      $��1* �6#   �� 5�      $
��1.2* �6#   .+�5�      &   System.Windows.Controls.DataGrid  $��1��5�      $��1��5�      
������    AutoGenerateColumns$ False��5�         
IsReadOnly$
 True��5�      ��5�      �� *
Supplies+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Product name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Product.Name+6`     5�      $ Quantity��6)   $ * 6X    6;   �� *
Quantity+6X     5�      $ Supply time��6)   $ * 6]    6>   �� *
SupplyTime+6]   5�      5�      5�      5�      