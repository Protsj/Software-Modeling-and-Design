namespace StoreAutomatization.Data;
using StoreAutomatization.Models;
using StoreAutomatization.Repositories;
public class MockData
{
    public static void Initialize(StoreRepository repository)
    {
        // ------------------ КАТЕГОРІЇ (Categories) ------------------
        repository.AddCategory(new Category { id = 1, name = "Фрукти та ягоди" });
        repository.AddCategory(new Category { id = 2, name = "Овочі та зелень" });
        repository.AddCategory(new Category { id = 3, name = "Гриби" });
        repository.AddCategory(new Category { id = 4, name = "Готова кулінарія" });
        repository.AddCategory(new Category { id = 5, name = "М'ясо" });
        repository.AddCategory(new Category { id = 6, name = "Птиця" });
        repository.AddCategory(new Category { id = 7, name = "М'ясні напівфабрикати" });
        repository.AddCategory(new Category { id = 8, name = "Ковбасні вироби та копченості" });
        repository.AddCategory(new Category { id = 9, name = "Риба та морепродукти" });
        repository.AddCategory(new Category { id = 10, name = "Молоко та вершки" });
        repository.AddCategory(new Category { id = 11, name = "Кисломолочні продукти" });
        repository.AddCategory(new Category { id = 12, name = "Масло та маргарин" });
        repository.AddCategory(new Category { id = 13, name = "Сири та сирні продукти" });
        repository.AddCategory(new Category { id = 14, name = "Яйця" });
        repository.AddCategory(new Category { id = 15, name = "Хліб" });
        repository.AddCategory(new Category { id = 16, name = "Здобна випічка" });
        repository.AddCategory(new Category { id = 17, name = "Кондитерські вироби" });
        repository.AddCategory(new Category { id = 18, name = "Солодощі та снеки" });
        repository.AddCategory(new Category { id = 19, name = "Крупи та бобові" });
        repository.AddCategory(new Category { id = 20, name = "Макаронні вироби" });
        repository.AddCategory(new Category { id = 21, name = "Борошно та інгредієнти для випічки" });
        repository.AddCategory(new Category { id = 22, name = "Рослинна олія, соуси та спеції" });
        repository.AddCategory(new Category { id = 23, name = "Консервація" });
        repository.AddCategory(new Category { id = 24, name = "Сухі сніданки" });
        repository.AddCategory(new Category { id = 25, name = "Підсолоджувачі" });
        repository.AddCategory(new Category { id = 26, name = "Кава" });
        repository.AddCategory(new Category { id = 27, name = "Чай" });
        repository.AddCategory(new Category { id = 28, name = "Какао та гарячий шоколад" });
        repository.AddCategory(new Category { id = 29, name = "Вода" });
        repository.AddCategory(new Category { id = 30, name = "Безалкогольні напої" });
        repository.AddCategory(new Category { id = 31, name = "Алкогольні напої" });
        repository.AddCategory(new Category { id = 32, name = "Напівфабрикати" });
        repository.AddCategory(new Category { id = 33, name = "Заморожені продукти" });
        repository.AddCategory(new Category { id = 34, name = "Морозиво та лід" });

        // ------------------ ТОВАРИ ТА ІНФОРМАЦІЯ (Products and ProductInfo) ------------------
        var product1 = new Product { id = 1, category_id = 1, name = "Яблука Голден", count = 150 };
        product1.SetInfo("100% яблука", 52, "Від +2°C до +4°C");
        repository.AddProduct(product1);

        var product2 = new Product { id = 2, category_id = 1, name = "Банани Еквадор", count = 200 };
        product2.SetInfo("100% банани", 89, "Від +12°C до +14°C");
        repository.AddProduct(product2);

        var product3 = new Product { id = 3, category_id = 1, name = "Лохина (упаковка)", count = 40 };
        product3.SetInfo("Ягоди лохини свіжі", 39, "Від 0°C до +4°C");
        repository.AddProduct(product3);

        var product4 = new Product { id = 4, category_id = 2, name = "Помідори Черрі", count = 80 };
        product4.SetInfo("Помідори", 18, "Від +10°C до +15°C");
        repository.AddProduct(product4);

        var product5 = new Product { id = 5, category_id = 2, name = "Огірки Естафета", count = 120 };
        product5.SetInfo("Огірки", 15, "Від +8°C до +10°C");
        repository.AddProduct(product5);

        var product6 = new Product { id = 6, category_id = 3, name = "Печериці свіжі", count = 50 };
        product6.SetInfo("Гриби печериці", 22, "Від +2°C до +4°C");
        repository.AddProduct(product6);

        var product7 = new Product { id = 7, category_id = 5, name = "Свинина (вирізка)", count = 25 };
        product7.SetInfo("Свинина", 12, "Від +2°C до +2°C");
        repository.AddProduct(product7);

        var product8 = new Product { id = 8, category_id = 6, name = "Філе куряче Наша Ряба", count = 60 };
        product8.SetInfo("М'ясо курчати-бройлера", 113, "Від 0°C до +2°C");
        repository.AddProduct(product8);

        var product9 = new Product { id = 9, category_id = 8, name = "Ковбаса Лікарська", count = 35 };
        product9.SetInfo("Свинина, яловичина, яйця, молоко, спеції", 257, "Від 0°C до +6°C");
        repository.AddProduct(product9);

        var product10 = new Product { id = 10, category_id = 9, name = "Стейк лосося охолоджений", count = 15 };
        product10.SetInfo("Сьомга атлантична", 142, "Від 0°C до +2°C");
        repository.AddProduct(product10);

        var product11 = new Product { id = 11, category_id = 10, name = "Молоко Яготинське 2.6%", count = 100 };
        product11.SetInfo("Молоко коров'яче незбиране, молоко знежирене", 53, "Від +2°C до +6°C");
        repository.AddProduct(product11);

        var product12 = new Product { id = 12, category_id = 11, name = "Кефір Галичина 1%", count = 45 };
        product12.SetInfo("Молоко коров'яче, закваска на кефірних грибках", 36, "Від +2°C до +6°C");
        repository.AddProduct(product12);

        var product13 = new Product { id = 13, category_id = 12, name = "Масло Селянське 73%", count = 80 };
        product13.SetInfo("Вершки з коров'ячого молока", 661, "Від -5°C до +5°C");
        repository.AddProduct(product13);

        var product14 = new Product { id = 14, category_id = 13, name = "Сир Твердий Комо Канторі", count = 30 };
        product14.SetInfo("Молоко коров'яче, сіль, закваска, фермент", 345, "Від -4°C до +6°C");
        repository.AddProduct(product14);

        var product15 = new Product { id = 15, category_id = 14, name = "Яйця курячі Ясенсвіт 10 шт", count = 200 };
        product15.SetInfo("Яйця курячі харчові", 157, "Від 0°C до +20°C");
        repository.AddProduct(product15);

        var product16 = new Product { id = 16, category_id = 15, name = "Хліб Бородінський нарізаний", count = 40 };
        product16.SetInfo("Борошно житнє, вода, солод, сіль, коріандр", 208, "При температурі не нижче +6°C");
        repository.AddProduct(product16);

        var product17 = new Product { id = 17, category_id = 15, name = "Батон Київський", count = 55 };
        product17.SetInfo("Борошно пшеничне, вода, дріжджі, цукор, сіль", 262, "При температурі не нижче +6°C");
        repository.AddProduct(product17);

        var product18 = new Product { id = 18, category_id = 17, name = "Торт Празький ROSHEN", count = 10 };
        product18.SetInfo("Цукор, масло, згущене молоко, какао, яйця", 412, "Від +2°C до +6°C");
        repository.AddProduct(product18);

        var product19 = new Product { id = 19, category_id = 19, name = "Гречка Сквірянка 1 кг", count = 120 };
        product19.SetInfo("Крупа гречана ядриця", 335, "У сухому прохолодному місці");
        repository.AddProduct(product19);

        var product20 = new Product { id = 20, category_id = 20, name = "Спагетті Barilla n.5", count = 90 };
        product20.SetInfo("Борошно з твердих сортів пшениці, вода", 359, "У сухому місці");
        repository.AddProduct(product20);

        var product21 = new Product { id = 21, category_id = 22, name = "Олія соняшникова Олейна 850 мл", count = 150 };
        product21.SetInfo("Олія соняшникова рафінована", 899, "У захищеному від світла місці");
        repository.AddProduct(product21);

        var product22 = new Product { id = 22, category_id = 26, name = "Кава в зернах Lavazza Oro 1 кг", count = 40 };
        product22.SetInfo("100% Арабіка", 2, "У сухому прохолодному місці");
        repository.AddProduct(product22);

        var product23 = new Product { id = 23, category_id = 27, name = "Чай чорний Lipton Yellow Label", count = 85 };
        product23.SetInfo("Чай чорний байховий", 1, "У сухому місці без сторонніх запахів");
        repository.AddProduct(product23);

        var product24 = new Product { id = 24, category_id = 29, name = "Вода Моршинська слабогазована 1.5л", count = 300 };
        product24.SetInfo("Вода мінеральна природна", 0, "Від +5°C до +25°C");
        repository.AddProduct(product24);

        var product25 = new Product { id = 25, category_id = 30, name = "Coca-Cola 2л", count = 180 };
        product25.SetInfo("Вода, цукор, діоксид вуглецю, барвник, кофеїн", 42, "Від 0°C до +20°C");
        repository.AddProduct(product25);

        var product26 = new Product { id = 26, category_id = 33, name = "Пельмені Три Ведмеді Фірмові 800г", count = 65 };
        product26.SetInfo("Борошно, м'ясо (свинина, яловичина), цибуля, сіль", 245, "При температурі -18°C");
        repository.AddProduct(product26);

        var product27 = new Product { id = 27, category_id = 34, name = "Морозиво Хрещатик Пломбір", count = 110 };
        product27.SetInfo("Молоко, вершкове масло, цукор, ванілін", 227, "При температурі -18°C");
        repository.AddProduct(product27);

        // ------------------ ЧЕКИ ТА АЙТЕМИ (Receipts and ReceiptItems) ------------------
        var receipt1 = new Receipt { id = 1, status = true, time = DateTime.Now.AddDays(-2).AddHours(10), customer_name = "Олександр Петренко", shop_name = "Сільпо" };
        receipt1.AddItem(1, 2); // Яблука (2 кг)
        receipt1.AddItem(4, 1); // Помідори Черрі (1 кг)
        receipt1.AddItem(8, 1); // Куряче філе (1 кг)
        repository.AddReceipt(receipt1);

        var receipt2 = new Receipt { id = 2, status = true, time = DateTime.Now.AddDays(-1).AddHours(15), customer_name = "Ірина Ковальчук", shop_name = "АТБ" };
        receipt2.AddItem(11, 2); // Молоко (2 шт)
        receipt2.AddItem(13, 1); // Масло (1 шт)
        receipt2.AddItem(17, 1); // Батон (1 шт)
        receipt2.AddItem(9, 1);  // Ковбаса Лікарська (1 шт)
        repository.AddReceipt(receipt2);

        var receipt3 = new Receipt { id = 3, status = false, time = DateTime.Now.AddHours(-3), customer_name = "Дмитро Мельник", shop_name = "Novus" };
        receipt3.AddItem(24, 6); // Моршинська (6 шт)
        receipt3.AddItem(25, 2); // Coca-Cola (2 шт)
        receipt3.AddItem(27, 3); // Морозиво (3 шт)
        repository.AddReceipt(receipt3);

        var receipt4 = new Receipt { id = 4, status = true, time = DateTime.Now.AddDays(-5).AddHours(18), customer_name = "Ольга Бойко", shop_name = "Ашан" };
        receipt4.AddItem(15, 1); // Яйця (1 уп)
        receipt4.AddItem(19, 2); // Гречка (2 кг)
        receipt4.AddItem(20, 3); // Спагетті (3 уп)
        receipt4.AddItem(21, 1); // Олія (1 шт)
        receipt4.AddItem(14, 1); // Сир Комо (1 шт)
        repository.AddReceipt(receipt4);

        var receipt5 = new Receipt { id = 5, status = true, time = DateTime.Now.AddDays(-1).AddHours(9), customer_name = "Максим Шевченко", shop_name = "Сільpo" };
        receipt5.AddItem(22, 1); // Кава Lavazza (1 уп)
        receipt5.AddItem(18, 1); // Торт Празький (1 шт)
        receipt5.AddItem(23, 1); // Чай Lipton (1 уп)
        repository.AddReceipt(receipt5);

        var receipt6 = new Receipt { id = 6, status = false, time = DateTime.Now.AddHours(-1), customer_name = "Анна Ткаченко", shop_name = "МегаМаркет" };
        receipt6.AddItem(26, 2); // Пельмені (2 уп)
        receipt6.AddItem(12, 1); // Кефір (1 шт)
        repository.AddReceipt(receipt6);

        var receipt7 = new Receipt { id = 7, status = true, time = DateTime.Now.AddDays(-10), customer_name = "Віктор Романенко", shop_name = "АТБ" };
        receipt7.AddItem(10, 2); // Стейк лосося (2 шт)
        receipt7.AddItem(3, 1);  // Лохина (1 уп)
        receipt7.AddItem(5, 1);  // Огірки (1 шт)
        receipt7.AddItem(6, 1);  // Печериці (1 шт)
        repository.AddReceipt(receipt7);
    }
}