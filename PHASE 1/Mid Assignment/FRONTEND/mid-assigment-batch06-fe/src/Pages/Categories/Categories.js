import { Button, Input, Modal, Space, Table } from 'antd';
import { Content } from 'antd/lib/layout/layout';
import { ExclamationCircleOutlined } from '@ant-design/icons';
import React, { useContext, useEffect, useState } from 'react';
import { createData, deleteData, getAllData, updateData } from '../../axiosAPIs';
import { CATEGORY } from '../../constants';
import AuthContext from '../../contexts/AuthContext';
import styles from './Categories.module.scss';

const Categories = () => {
  const [dataState, setDataState] = useState([]);
  const [dataAdd, setDataAdd] = useState({ CategoryName: '' });
  const [dataUpdate, setDataUpdate] = useState({ CategoryId: null, CategoryName: '' });
  const [error, setError] = useState('');
  const [buttonDisabled, setButtonDisabled] = useState(true);
  const [isModalOpenAdd, setIsModalOpenAdd] = useState(false);
  const [isModalOpenUpdate, setIsModalOpenUpdate] = useState(false);
  const { confirm } = Modal;

  const getData = async () => {
    const data = await getAllData(CATEGORY);
    setDataState(data);
  };

  useEffect(() => {
    getData();
  }, []);

  const { auth } = useContext(AuthContext);

  const columns = [
    {
      title: 'ID',
      dataIndex: '$id',
      key: '$id',
    },
    {
      title: 'Name',
      dataIndex: 'categoryName',
      key: 'categoryName',
      sorter: (a, b) => a.categoryName.localeCompare(b.categoryName),
    },
    {
      title: 'Category Id',
      dataIndex: 'categoryId',
      key: 'categoryId',
      sorter: (a, b) => a.categoryId.localeCompare(b.categoryId),
    },
    {
      title: 'Action',
      key: 'action',
      render: (_, record) => (
        <Space size="middle">
          <Button type="primary" onClick={() => showModalUpdate(record)}>
            Update
          </Button>
          <Button type="primary" danger onClick={() => showConfirmDelete(record)}>
            Delete
          </Button>
        </Space>
      ),
      hidden: auth?.roles?.find(roleasd => auth?.roles?.includes(roleasd)) === '0' ? false : true,
    },
  ].filter((column) => !column.hidden);

  const onSearch = (value) => console.log(value);

  const handleDelete = async (record) => {
    await deleteData(CATEGORY, record.categoryId);
    getData();
  };

  // Add
  const showModalAdd = () => {
    setIsModalOpenAdd(true);
    setError('');
    setButtonDisabled(true);
  };
  const handleOkAdd = async () => {
    setIsModalOpenAdd(false);
    await createData(CATEGORY, dataAdd);
    getData();
    setDataAdd({ CategoryName: '' });
  };

  const handleCancelAdd = () => {
    setIsModalOpenAdd(false);
  };

  const handleBlurAdd = (e) => {
    if (e.target.value) {
      setError('');
    } else {
      setError('This field is required');
    }
  };

  const handleChangeAdd = (e) => {
    setError('');
    setDataAdd({ [e.target.name]: e.target.value });
  };
  // End Add

  // Update
  const showModalUpdate = (record) => {
    setIsModalOpenUpdate(true);
    setError('');
    setDataUpdate({ CategoryId: record.categoryId, CategoryName: record.categoryName });
    setButtonDisabled(true);
  };

  const handleBlurUpdate = (e) => {
    if (e.target.value) {
      setError('');
    } else {
      setError('This field is required');
    }
  };

  const handleChangeUpdate = (e) => {
    setError('');
    setDataUpdate({ ...dataUpdate, [e.target.name]: e.target.value });
  };

  const handleOkUpdate = async () => {
    setIsModalOpenUpdate(false);
    await updateData(CATEGORY, dataUpdate);
    getData();
  };

  const handleCancelUpdate = () => {
    setIsModalOpenUpdate(false);
  };
  // End Update

  useEffect(() => {
    if (dataAdd || dataUpdate) {
      setButtonDisabled(false);
    }
  }, [dataAdd, dataUpdate]);

  const showConfirmDelete = (record) => {
    confirm({
      title: 'Do you want to delete this category?',
      icon: <ExclamationCircleOutlined />,
      onOk() {
        handleDelete(record);
      },
      onCancel() { },
    });
  };

  return (
    <>
      <Content className="container">
        <Space direction="vertical" size="middle" style={{ display: 'flex' }}>
          {' '}
          <div className={styles.headerTable}>
            <h1>List Category</h1>
            <div className="d-flex">
              <Input.Search placeholder="input search" allowClear onSearch={onSearch} className={styles.searchTable} />
              {auth?.roles?.find(roleasd => auth?.roles?.includes(roleasd)) === '0' && (
                <Button type="primary" onClick={showModalAdd}>
                  Add
                </Button>
              )}
            </div>
          </div>
          <Table rowKey={(dataState) => dataState.id} columns={columns} dataSource={dataState} />
        </Space>

        <Modal
          title="Create Category"
          open={isModalOpenAdd}
          onOk={handleOkAdd}
          okButtonProps={{ disabled: buttonDisabled }}
          onCancel={handleCancelAdd}
          destroyOnClose={true}
        >
          <Input
            placeholder="Name"
            name="CategoryName"
            onBlur={handleBlurAdd}
            onChange={handleChangeAdd} />
          {error && <p className={styles.msgError}>{error}</p>}
        </Modal>

        <Modal
          title="Update Category"
          open={isModalOpenUpdate}
          onOk={handleOkUpdate}
          okButtonProps={{ disabled: buttonDisabled }}
          onCancel={handleCancelUpdate}
          destroyOnClose={true}
        >
          <Input
            placeholder="Name"
            name="CategoryName"
            onBlur={handleBlurUpdate}
            value={dataUpdate.CategoryName}
            onChange={handleChangeUpdate}
          />
          {error && <p className={styles.msgError}>{error}</p>}
        </Modal>
      </Content>
    </>
  );
};

export default Categories;
