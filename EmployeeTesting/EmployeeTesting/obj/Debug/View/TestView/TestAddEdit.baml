   M S B A M L   `   `   `  ����J  FEmployeeTesting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:EmployeeTesting.View.TestViewEmployeeTesting.View.TestView  5      /    )EmployeeTesting.View.TestView.TestAddEdit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:EmployeeTesting.View.TestView     5        N� Title$  TestAddEdit��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $!��Название теста��6   $��Center=�6*    	  Label#��[  6E   �� 5   
   $
��Wrap=�6   $E��?Количество баллов для прохождения��6(   $��1��6Q   $��Center=�6^   #��[  6y   �� 5   
   $��5,5,60,5q�6    �� 	MaxLength$ 80��6$   $��1��6O   ��63   �� *
Test_Title+6O   �� 5   
   $��5,5,60,5q�6   $	��200��6$   $
��Left=�60   $��1��6K   $ 4��6X   $��1��6�   ��6f   �� *Passing_Points+6�   �� 5   
   $	��Top=�6   $��Вопросы��6,   $��3��6;   $��2��6H   $��Center=�6\   #��[  6y   �� 5   
   -   5         ��Name$ AddQuestionBtn��5      $#��Добавить вопрос��6F   $	��Top=�6`   $��Right=�6x   $��3��6�   $��2��6�   &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ QuestionsData��5!   j   $��5q�6   $��4��6      HeadersVisibility$
 None=�6Q   $��2��6�   ��6+   �� *Test_Question+   Columns 5"      4  .System.Windows.Controls.DataGridTemplateColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)   	   CellTemplate	 5$      �� 5%      .R�5&      � $��0,0,0,15q�6#    5'   "   �� 5(   &   $	��200 �67   �� 5)   &    5+   "   �� 5,   &   �� 5-   &   �� 5.   &   �� 5/   &   $
��Auto �64   .+�52   "   �� $��Вопрос��6,   $��Center=�6:   #��[  6U   �� 53   "   $��1��6,   $'��!Количество баллов��69   $��Center=�6R   #��[  6m   �� 54   "   $��2��6,   $��
Ответ��69   $��Center=�6F   #��[  6a   �� 56   "   $��5q�6*   
 �� AcceptsReturn
 .  �� TextWrapping$
 Wrap=�6�   $	��100��6�   $��1��6�   ��6J   �� *
Question+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 57   "   $��5q�6*   $	��200��65   $
��Left=�6A   $��1��6\   $ 4��6i   $��1��6�   ��6w   �� *Points+$ TwoWay=�$ PropertyChanged=�6�   �� 58   "   $��5q�6*   
 . $��2��6�   $
 Wrap=�6�   $	��100��6�   $��1��6�   ��6J   �� *Answer+$ TwoWay=�$ PropertyChanged=�6�   �� 5:   "   $ DeleteQuestionBtn��6)   -   5        $��3��5:   D   $��Удалить��6Q   $��Right=�6c   $��2��6   6�   5;      5<      5>      5@      �� 5B   
   -   5        $ SaveBtn��5B      $��Сохранить��68   $��5��6L   $��Right=�6Y   $��2��6u   5C      5D      