   M S B A M L   `   `   `  ����O  KBuild-A-Bike_Program, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Build_A_Bike_ProgramBuild_A_Bike_Program  5   	   (    "Build_A_Bike_Program.DetailsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Build_A_Bike_Program     5   	     � Title$  Build-A-Bike��5   	   $��535.295��6   $��333.614��6/   .��5	      � .+�5
   
   �� -   5         ��Name$ completeButton��5
      $'��!Make Payment and
 Complete Order��6)   $
��Left=�6]   $��
21,439,0,0q�6x   $	��Top=�6�   $	��133��6�   $��42��6�   6�   �� 5   
   -   5        $ cancelButton��5      $��Cancel Order��6'   $
��Left=�6>   $��167,439,0,0q�6Y   $	��Top=�6n   $	��133��6�   $��42��6�   6�   �� 5   
   -   5         ��Name$ label��5      $��	Full Name��6   $
��Left=�63   $��	10,29,0,0q�6N   $	��Top=�6a   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��23��6>   $��	21,55,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��279��6�   �� 5   
   -   5        $ 
label_Copy��5      $��Your Details:��6$   $
��Left=�6<   $��
116,10,0,0q�6W   $	��Top=�6k   $
��Bold"�6�   �� 5   
   $
��Left=�6   $��16��6/   $��
123,20,0,0q�6;   $	��Top=�6O   $��68��6g    J� RenderTransformOrigin$ 0.5,0.5&�6r   �� 5   
   -   5        $ label_Copy1��5      $��Address��6%   $
��Left=�67   $��	10,79,0,0q�6R   $	��Top=�6e   �� 5   
   -   5        $ 
addressBox��5      $
��Left=�6&   $��23��6A   $��
21,105,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��279��6�   �� 5   
   -   5        $ label_Copy2��5      $��Email��6%   $
��Left=�65   $��
10,129,0,0q�6P   $	��Top=�6d   �� 5   
   -	   5        $ emailBox��5      $
��Left=�6$   $��23��6?   $��
21,155,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��279��6�   �� 5   
   -
   5        $ label_Copy3��5      $��Card Number��6%   $
��Left=�6;   $��
10,270,0,0q�6V   $	��Top=�6j   �� 5   
   -   5        $ 	cardNoBox��5      $
��Left=�6%   $��23��6@   $��
21,296,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��279��6�   �� 5   
   -   5        $ label_Copy4��5      $��	Full Name��6%   $
��Left=�69   $��	10,29,0,0q�6T   $	��Top=�6g   �� 5   
   -   5        $ nameBox��5      $
��Left=�6#   $��23��6>   $��	21,55,0,0q�6J   $
 Wrap=�6]   $	��Top=�6q   $	��279��6�   �� 5   
   -   5        $ label_Copy5��5      $��Payment Details:��6%   $
��Left=�6@   $��111,194,0,0q�6[   $	��Top=�6p   $
��Bold"�6�   �� 5   
   $
��Left=�6   $��16��6/   $��116,204,0,0q�6;   $	��Top=�6P   $��95��6h   $ 0.5,0.5&�6s   �� 5   
   -   5        $ depositLabel��5      $J��DA deposit of £0.00 (10% of total cost) 
is required on this order.��6&   $
��Left=�6|   $��
21,220,0,0q�6�   $	��Top=�6�   $	��279��6�   $��48��6�   �� 5   
   -   5        $ label_Copy6��5      $��Full Name on Card��6%   $
��Left=�6A   $��
10,320,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ cardNameBox��5      $
��Left=�6'   $��23��6B   $��
21,346,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $	��279��6�   �� 5   
   -   5        $ label_Copy7��5      $	��CVC��6%   $
��Left=�63   $��
10,366,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $ cvcBox��5      $
��Left=�6"   $��23��6=   $��
21,392,0,0q�6I   $
 Wrap=�6]   $	��Top=�6q   $	��279��6�   5       5!      