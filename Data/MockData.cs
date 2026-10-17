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

        // ------------------ ТОВАРИ (Products) ------------------
        repository.AddProduct(new Product { id = 1, category_id = 1, name = "Яблука Голден", count = 150 });
        repository.AddProduct(new Product { id = 2, category_id = 1, name = "Банани Еквадор", count = 200 });
        repository.AddProduct(new Product { id = 3, category_id = 1, name = "Лохина (упаковка)", count = 40 });
        repository.AddProduct(new Product { id = 4, category_id = 2, name = "Помідори Черрі", count = 80 });
        repository.AddProduct(new Product { id = 5, category_id = 2, name = "Огірки Естафета", count = 120 });
        repository.AddProduct(new Product { id = 6, category_id = 3, name = "Печериці свіжі", count = 50 });
        repository.AddProduct(new Product { id = 7, category_id = 5, name = "Свинина (вирізка)", count = 25 });
        repository.AddProduct(new Product { id = 8, category_id = 6, name = "Філе куряче Наша Ряба", count = 60 });
        repository.AddProduct(new Product { id = 9, category_id = 8, name = "Ковбаса Лікарська", count = 35 });
        repository.AddProduct(new Product { id = 10, category_id = 9, name = "Стейк лосося охолоджений", count = 15 });
        repository.AddProduct(new Product { id = 11, category_id = 10, name = "Молоко Яготинське 2.6%", count = 100 });
        repository.AddProduct(new Product { id = 12, category_id = 11, name = "Кефір Галичина 1%", count = 45 });
        repository.AddProduct(new Product { id = 13, category_id = 12, name = "Масло Селянське 73%", count = 80 });
        repository.AddProduct(new Product { id = 14, category_id = 13, name = "Сир Твердий Комо Канторі", count = 30 });
        repository.AddProduct(new Product { id = 15, category_id = 14, name = "Яйця курячі Ясенсвіт 10 шт", count = 200 });
        repository.AddProduct(new Product { id = 16, category_id = 15, name = "Хліб Бородінський нарізаний", count = 40 });
        repository.AddProduct(new Product { id = 17, category_id = 15, name = "Батон Київський", count = 55 });
        repository.AddProduct(new Product { id = 18, category_id = 17, name = "Торт Празький ROSHEN", count = 10 });
        repository.AddProduct(new Product { id = 19, category_id = 19, name = "Гречка Сквірянка 1 кг", count = 120 });
        repository.AddProduct(new Product { id = 20, category_id = 20, name = "Спагетті Barilla n.5", count = 90 });
        repository.AddProduct(new Product { id = 21, category_id = 22, name = "Олія соняшникова Олейна 850 мл", count = 150 });
        repository.AddProduct(new Product { id = 22, category_id = 26, name = "Кава в зернах Lavazza Oro 1 кг", count = 40 });
        repository.AddProduct(new Product { id = 23, category_id = 27, name = "Чай чорний Lipton Yellow Label", count = 85 });
        repository.AddProduct(new Product { id = 24, category_id = 29, name = "Вода Моршинська слабогазована 1.5л", count = 300 });
        repository.AddProduct(new Product { id = 25, category_id = 30, name = "Coca-Cola 2л", count = 180 });
        repository.AddProduct(new Product { id = 26, category_id = 33, name = "Пельмені Три Ведмеді Фірмові 800г", count = 65 });
        repository.AddProduct(new Product { id = 27, category_id = 34, name = "Морозиво Хрещатик Пломбір", count = 110 });

        // ------------------ ІНФОРМАЦІЯ ПРО ТОВАРИ (ProductInfo) ------------------
        repository.AddProductInfo(new ProductInfo { id = 1, product_id = 1, compositions = "100% яблука", calories = 52, storage_conditions = "Від +2°C до +4°C" });
        repository.AddProductInfo(new ProductInfo { id = 2, product_id = 2, compositions = "100% банани", calories = 89, storage_conditions = "Від +12°C до +14°C" });
        repository.AddProductInfo(new ProductInfo { id = 3, product_id = 3, compositions = "Ягоди лохини свіжі", calories = 39, storage_conditions = "Від 0°C до +4°C" });
        repository.AddProductInfo(new ProductInfo { id = 4, product_id = 4, compositions = "Помідори", calories = 18, storage_conditions = "Від +10°C до +15°C" });
        repository.AddProductInfo(new ProductInfo { id = 5, product_id = 5, compositions = "Огірки", calories = 15, storage_conditions = "Від +8°C до +10°C" });
        repository.AddProductInfo(new ProductInfo { id = 6, product_id = 6, compositions = "Гриби печериці", calories = 22, storage_conditions = "Від +2°C до +4°C" });
        repository.AddProductInfo(new ProductInfo { id = 7, product_id = 7, compositions = "Свинина 100%", calories = 143, storage_conditions = "Від 0°C до +2°C" });
        repository.AddProductInfo(new ProductInfo { id = 8, product_id = 8, compositions = "М'ясо курчати-бройлера", calories = 113, storage_conditions = "Від 0°C до +2°C" });
        repository.AddProductInfo(new ProductInfo { id = 9, product_id = 9, compositions = "Свинина, яловичина, яйця, молоко, спеції", calories = 257, storage_conditions = "Від 0°C до +6°C" });
        repository.AddProductInfo(new ProductInfo { id = 10, product_id = 10, compositions = "Сьомга атлантична", calories = 142, storage_conditions = "Від 0°C до +2°C" });
        repository.AddProductInfo(new ProductInfo { id = 11, product_id = 11, compositions = "Молоко коров'яче незбиране, молоко знежирене", calories = 53, storage_conditions = "Від +2°C до +6°C" });
        repository.AddProductInfo(new ProductInfo { id = 12, product_id = 12, compositions = "Молоко коров'яче, закваска на кефірних грибках", calories = 36, storage_conditions = "Від +2°C до +6°C" });
        repository.AddProductInfo(new ProductInfo { id = 13, product_id = 13, compositions = "Вершки з коров'ячого молока", calories = 661, storage_conditions = "Від -5°C до +5°C" });
        repository.AddProductInfo(new ProductInfo { id = 14, product_id = 14, compositions = "Молоко коров'яче, сіль, закваска, фермент", calories = 345, storage_conditions = "Від -4°C до +6°C" });
        repository.AddProductInfo(new ProductInfo { id = 15, product_id = 15, compositions = "Яйця курячі харчові", calories = 157, storage_conditions = "Від 0°C до +20°C" });
        repository.AddProductInfo(new ProductInfo { id = 16, product_id = 16, compositions = "Борошно житнє, вода, солод, сіль, коріандр", calories = 208, storage_conditions = "При температурі не нижче +6°C" });
        repository.AddProductInfo(new ProductInfo { id = 17, product_id = 17, compositions = "Борошно пшеничне, вода, дріжджі, цукор, сіль", calories = 262, storage_conditions = "При температурі не нижче +6°C" });
        repository.AddProductInfo(new ProductInfo { id = 18, product_id = 18, compositions = "Цукор, масло, згущене молоко, какао, яйця", calories = 412, storage_conditions = "Від +2°C до +6°C" });
        repository.AddProductInfo(new ProductInfo { id = 19, product_id = 19, compositions = "Крупа гречана ядриця", calories = 335, storage_conditions = "У сухому прохолодному місці" });
        repository.AddProductInfo(new ProductInfo { id = 20, product_id = 20, compositions = "Борошно з твердих сортів пшениці, вода", calories = 359, storage_conditions = "У сухому місці" });
        repository.AddProductInfo(new ProductInfo { id = 21, product_id = 21, compositions = "Олія соняшникова рафінована", calories = 899, storage_conditions = "У захищеному від світла місці" });
        repository.AddProductInfo(new ProductInfo { id = 22, product_id = 22, compositions = "100% Арабіка", calories = 2, storage_conditions = "У сухому прохолодному місці" });
        repository.AddProductInfo(new ProductInfo { id = 23, product_id = 23, compositions = "Чай чорний байховий", calories = 1, storage_conditions = "У сухому місці без сторонніх запахів" });
        repository.AddProductInfo(new ProductInfo { id = 24, product_id = 24, compositions = "Вода мінеральна природна", calories = 0, storage_conditions = "Від +5°C до +25°C" });
        repository.AddProductInfo(new ProductInfo { id = 25, product_id = 25, compositions = "Вода, цукор, діоксид вуглецю, барвник, кофеїн", calories = 42, storage_conditions = "Від 0°C до +20°C" });
        repository.AddProductInfo(new ProductInfo { id = 26, product_id = 26, compositions = "Борошно, м'ясо (свинина, яловичина), цибуля, сіль", calories = 245, storage_conditions = "При температурі -18°C" });
        repository.AddProductInfo(new ProductInfo { id = 27, product_id = 27, compositions = "Молоко, вершкове масло, цукор, ванілін", calories = 227, storage_conditions = "При температурі -18°C" });

        // ------------------ ЧЕКИ (Receipts) ------------------
        repository.AddReceipt(new Receipt { id = 1, status = true, time = DateTime.Now.AddDays(-2).AddHours(10), customer_name = "Олександр Петренко", shop_name = "Сільпо" });
        repository.AddReceipt(new Receipt { id = 2, status = true, time = DateTime.Now.AddDays(-1).AddHours(15), customer_name = "Ірина Ковальчук", shop_name = "АТБ" });
        repository.AddReceipt(new Receipt { id = 3, status = false, time = DateTime.Now.AddHours(-3), customer_name = "Дмитро Мельник", shop_name = "Novus" });
        repository.AddReceipt(new Receipt { id = 4, status = true, time = DateTime.Now.AddDays(-5).AddHours(18), customer_name = "Ольга Бойко", shop_name = "Ашан" });
        repository.AddReceipt(new Receipt { id = 5, status = true, time = DateTime.Now.AddDays(-1).AddHours(9), customer_name = "Максим Шевченко", shop_name = "Сільпо" });
        repository.AddReceipt(new Receipt { id = 6, status = false, time = DateTime.Now.AddHours(-1), customer_name = "Анна Ткаченко", shop_name = "МегаМаркет" });
        repository.AddReceipt(new Receipt { id = 7, status = true, time = DateTime.Now.AddDays(-10), customer_name = "Віктор Романенко", shop_name = "АТБ" });

        // ------------------ АЙТЕМИ ЧЕКІВ (ReceiptItems) ------------------
        // Чек 1: Овочі, фрукти та курка
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 1, product_id = 1, count = 2 }); // Яблука (2 кг)
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 1, product_id = 4, count = 1 }); // Помідори Черрі
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 1, product_id = 8, count = 1 }); // Куряче філе

        // Чек 2: Молочка, хліб та ковбаса
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 2, product_id = 11, count = 2 }); // Молоко (2 шт)
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 2, product_id = 13, count = 1 }); // Масло
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 2, product_id = 17, count = 1 }); // Батон
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 2, product_id = 9, count = 1 });  // Ковбаса Лікарська

        // Чек 3: Напої та снеки (Статус - в процесі/неоплачений)
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 3, product_id = 24, count = 6 }); // Моршинська (6 шт)
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 3, product_id = 25, count = 2 }); // Coca-Cola
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 3, product_id = 27, count = 3 }); // Морозиво

        // Чек 4: Базові продукти та бакалія
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 4, product_id = 15, count = 1 }); // Яйця
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 4, product_id = 19, count = 2 }); // Гречка (2 кг)
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 4, product_id = 20, count = 3 }); // Спагетті
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 4, product_id = 21, count = 1 }); // Олія
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 4, product_id = 14, count = 1 }); // Сир Комо

        // Чек 5: Кава та торт
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 5, product_id = 22, count = 1 }); // Кава Lavazza
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 5, product_id = 18, count = 1 }); // Торт Празький
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 5, product_id = 23, count = 1 }); // Чай

        // Чек 6: Напівфабрикати
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 6, product_id = 26, count = 2 }); // Пельмені (2 уп)
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 6, product_id = 12, count = 1 }); // Кефір

        // Чек 7: Лосось, овочі
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 7, product_id = 10, count = 2 }); // Стейк лосося
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 7, product_id = 3, count = 1 });  // Лохина
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 7, product_id = 5, count = 1 });  // Огірки
        repository.AddReceiptItem(new ReceiptItem { receipt_id = 7, product_id = 6, count = 1 });  // Печериці
    }
}