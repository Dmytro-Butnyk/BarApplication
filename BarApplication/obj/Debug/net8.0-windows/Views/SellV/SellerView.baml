   M S B A M L   `   `   `  ����I  EBarApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BarApplication.ViewsBarApplication.Views  5      %    BarApplication.Views.SellerView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:BarApplication.Views     5      $
��1080��5      $	��520��5	        N� Title$  
SellerView��5
       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $$ ../Resources/ButtonStyles.xaml?�6%   �� 5      $# ../Resources/ButtonIcons.xaml?�6%   %    5      .��5      � 
���   � � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��6* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��8* �6   �� 5      $
��1.5* �6   .+�5    
   � $��2��6   .+�5!      ��  �� Orientation$ Vertical=�6   .+�5"      �� $��ORDERS��6      	WhiteText#��[  5#      $��50(�5$      $��Center=�5%      $	��Top=�5&      �� 5'      $��SELLER��6   #��[  5(      $��0,0,0,5q�5)      $��26(�5*      $��Center=�5+      $	��Top=�5,      5-      �� 5/      $%��../Resources/Images/AB_icon.png��6   $��Center=�50      $��Right=�51      $��90��52      53      �� 55   
   -   5         ��Name$ DropDownMenu��56      $��3��57       K� ZIndex$ 1��58      $��55��59      $
��Left=�5:      $y�Visible=�5;      $��1q�5<      
���   �._�5>      � ���#ff9000$��3��5@       5A      �� 5B      $��2* �6$   �� 5C      $��2* �6$   �� 5D      $��6* �6$   �� 5E      $
��1.5* �6$   .+�5H      �� -   5        $��OpenB��5H      $��1��5J      $y�Visible=�5K        MenuButtonStyle#��[ 5L        MenuIcon
	 � Tag#	 [ 5M      �� 5O      -   5        $��HideB��5O      $��1��5Q      $y�Hidden=�5R      #��[ 5S      #	 [ 5T      �� 5V      $��Seller
Orders��5W      $��26(�5X      $
��Bold"�5Y      $��45,0,0,0q�5Z      $��Right=�5[      $��Center=�5\      �� 5^      $��DETAILS��5`      $��Center=�5a      $��1��5b       " MenuInterfaceButtonStyleSeller#��[ 5c        OrderDetailsIcon#	 [ 5d      ��5_      �� *GoToOrderDetails+5d      �� 5f      $
��AUTH��5h      $��3��5i      #��[ 5j        AuthorizationSellIcon#	 [ 5k      ��5g      �� *GoToAuthorization+5k      5l      5n      � 5o   
   
�������$��2��5p      $��1��5q      $��65,0,0,0q�5r       5s      �� 5t      $��2* �6#   �� 5u      $��3* �6#   .+�5w      �  5x      �� 5y      $��* �6$   �� 5z      $��* �6$   �� 5{      $��* �6$   �� 5|      $��* �6$   �� 5}      $��* �6$   .+�5      �� $��Table Number:��6   $��1��5�      $��Center=�5�      $��18(�5�      �� 5�      
 �� DisplayMemberPath$
 Number��5�      $��1��5�      $��0��5�      $��Center=�5�      $	��150��5�      ��5�      �� *Tables+ �� SelectedItem 5�      �� *SelectedTable+5�      �� 5�      $��Order Date:��6   $��2��5�      $��Center=�5�      $��18(�5�      �� 5�      $��2��5�      $��0��5�      $	��150��5�      $��Center=�5�      ��5�      �� *	OrderDate+5�      �� 5�        RoundedCornerButtonStyle#��[ 5�      
������$��	Add Order��5�      $��20(�5�      $	��150��5�      $��3��5�      $
��0,10q�5�      $��Center=�5�      ��5�      �� *AddOrderCommand+5�      5�      5�      � 5�   
   $��2��6   $��1��6   $��10q�6,   ���#1A1A1A 5�      �� 5�      $
��Auto �6    �� 5�      $��* �6    �� 5�      $
��Auto �6    .+�5�      �� $��Orders��6   $��20(�6%   $
��Bold"�63   #��[  5�      &   System.Windows.Controls.DataGrid  5�         AutoGenerateColumns$ False��5�      $��1��5�         	RowHeight$ 30Q�5�      $��1��5�      
������    
IsReadOnly$
 True��5�      ��5�      �� *Orders+ 5�      �� *SelectedOrder+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Table��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Table.Number+6Y     5�      $ 
Order Time��6)   $ * 6V    6=   �� *Date+6V   5�      �� 5�      $��2��6   $ 
Horizontal=�6&   $
��0,10q�6?   .+�5�      �� $��Opened��5�      $��0,0,10,0q�6&   
���������5�      �� *ShowOpenedCommand+��5�      �� *IsOpenedButtonSelected+5�      �� 5�      $��Closed��5�      $��0,0,10,0q�6&   
���������5�      �� *ShowClosedCommand+��5�      �� *IsClosedButtonSelected+5�      �� 5�      #��[ 5�      $��Close Order ��5�      $��50,0,0,0q�6,   $	��100��5�      ��5�      �� *CloseOrderCommand+5�      �� 5�      ${�False��6   $��Order Status��5�      
�������$��Center=�5�      $
��30,0q�5�      $��3��5�      $��2��5�       d� 	IsChecked 5�      �� *SelectedOrder.IsOpened+5�      5�      5�      5�      5�      