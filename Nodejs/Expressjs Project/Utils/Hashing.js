const bcrypt = require("bcrypt");
const hashPassword = async function (password,saltRounds) {
    // const hash = await bcrypt.hash(password,saltRounds)
    const salt = await bcrypt.genSalt(saltRounds)
    const hash = await bcrypt.hash(password,salt)
    return hash;
}


const comparePassword = async function (password,hash) {
    const result = await bcrypt.compare(password,hash);
    return result;
};

// (async () => {
//     const hash = await hashPassword('123',10);
//     console.log("For Password (123) ===> ", await comparePassword('123',hash)); //! true
//     console.log("For Password (456) ===> ", await comparePassword('456',hash)); //! false
// })();


//! hash:  $2b$10$KICQOp5jRsKERAoEEQuavOpB6BVSO9mTFoQyVPHS6xz8mg.jziCta
//! hash:  $2b$10$ZVCCBnGcU9MoziFEyQGoVeaflHhzUPNkNvRMnx4LBQif8dOmsg/yO

//! salt:  $2b$10$Ofi8rCK3ETcBJ8gdOItQ7.
//! hash:  $2b$10$Ofi8rCK3ETcBJ8gdOItQ7.VxwKnMBbvwzhNV2xYd9G.V400/SAqYO

//! salt:  $2b$10$u2XcCie5jMci83QBUoTVXO
//! hash:  $2b$10$u2XcCie5jMci83QBUoTVXOqlNV/1ZT3v5JAhtL89woZEytCY3gaFu