   M S B A M L   `   `   `  ����J  FEmployeeTesting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:EmployeeTesting.View.EmployeeView!EmployeeTesting.View.EmployeeView  5      7    1EmployeeTesting.View.EmployeeView.EmployeeAddEdit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:EmployeeTesting.View.EmployeeView     5        N� Title$  EmployeeAddEdit��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��Center=�6    	  Label#��[  6/   $��Фамилия��6N   �� 5   
   $��Center=�6   #��[  6/   $��1��6N   $��Имя��6[   �� 5   
   $��Center=�6   #��[  6/   $��2��6N   $��Отчество��6[   �� 5   
   $��Center=�6   #��[  6/   $��3��6N   $��Должность��6[   �� 5   
   $��5,5,60,5q�6    �� 	MaxLength$ 80��6$   $��1��6L   ��63   �� *	Surname+6L   �� 5   
   $��5,5,60,5q�6   $ 80��6$   $��1��6I   $��1��6V   ��63   �� *Name+6V   �� 5   
   $��5,5,60,5q�6   $ 80��6$   $��2��6O   $��1��6\   ��63   �� *
Middlename+6\   �� 5    
   -   5         ��Name$ PositionComboBox��5    `   $��5,5,60,5q�6    �� DisplayMemberPath$
 Name��6%   $��3��6z   $��1��6�    �� SelectedItem 6>   �� *
Position+6�   �� 5"   
   -   5         ��Name$ SaveBtn��5"      $��Сохранить��68   $��5��6L   $��2��6Y   $��Right=�6m   5#      5$      