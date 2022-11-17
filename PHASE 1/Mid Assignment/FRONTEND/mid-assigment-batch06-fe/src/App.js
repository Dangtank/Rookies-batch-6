import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Navbar from './Components/Navbar/Navbar';
import Home from './Pages/Home/Home';
import Login from './Pages/Login/Login';
import Categories from './Pages/Categories/Categories';
import './styles/index.scss';
import { Routes, Route } from 'react-router-dom';
import Books from './Pages/Books/Books';
import ListRequest from './Pages/ListRequest/ListRequest';
import Layout from './Pages/Layout/Layout';
import RequireAuth from './Pages/RequireAuth/RequireAuth';
import Unauthorized from './Pages/Unauthorized/Unauthorized';
import Missing from './Pages/Missing/Missing';
import BookBorrowed from './Pages/BookBorrowed/BookBorrowed';

const App = () => {

  const ROLES = {
    'User': "1",
    'Admin': "0"
  }

  return (
    <>
     <Navbar />
    <Routes>
        <Route path="/" element={<Layout />}>
          {/* public routes */}
          <Route path="login" element={<Login />} />
          <Route path="unauthorized" element={<Unauthorized />} />

          {/* we want to protect these routes */}
          <Route element={<RequireAuth allowedRoles={[ROLES.User]} />}>
            <Route path="/" element={<Home />} />
          </Route>

          <Route element={<RequireAuth allowedRoles={[ROLES.User, ROLES.Admin]} />}>
            <Route path="categories" element={<Categories />} />
          </Route>

          <Route element={<RequireAuth allowedRoles={[ROLES.User, ROLES.User, ROLES.Admin]} />}>
            <Route path="books" element={<Books />} />
          </Route>
          <Route element={<RequireAuth allowedRoles={[ROLES.Admin]} />}>
            <Route path="list-request" element={<ListRequest />} />
          </Route>
          <Route element={<RequireAuth allowedRoles={[ROLES.User]} />}>
            <Route path="book-borrowed" element={<BookBorrowed />} />
          </Route>

          {/* catch all */}
          <Route path="*" element={<Missing />} />
        </Route>
      </Routes>
    </>
    
  );
};

export default App;
